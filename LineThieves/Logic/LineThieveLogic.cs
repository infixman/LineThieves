using ImageMagick;
using LineThieves.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Telegram.Bot;

namespace LineThieves.Logic
{
    public class LineThieveLogic
    {
        private int _userId;
        private string _botKey;
        private string _botName;
        private const string _searchApi = "https://store.line.me/api/search/sticker?query=@KEYWORD@&offset=@PAGESETS@&limit=@SEARCHLIMIT@&type=ALL&includeFacets=true";
        private const string _downloadApi = "http://dl.stickershop.line.naver.jp/products/0/0/1/@ID@/iphone/stickers@2x.zip";
        
        private const int _stickerWidth = 512;
        private const int _stickerHeight = 512;

        public LineThieveLogic(int userId, string botKey, string botName)
        {
            _userId = userId;
            _botKey = botKey;
            _botName = botName.Replace("@", string.Empty);
        }

        public SimpleLineSearchResult SearchLineSticker(string keyWord, int searchLimit, int searchSkip)
        {
            var apiUrl = _searchApi
                        .Replace("@KEYWORD@", HttpUtility.UrlEncode(keyWord, System.Text.Encoding.UTF8))
                        .Replace("@PAGESETS@", (searchSkip * searchLimit).ToString())
                        .Replace("@SEARCHLIMIT@", searchLimit.ToString());

            var client = new HttpClient();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("zh-TW"));

            var searchResponse = client.GetAsync(apiUrl).Result;
            var returnResult = new SimpleLineSearchResult();

            if (true == searchResponse.IsSuccessStatusCode)
            {
                var searchResult = JsonConvert.DeserializeObject<LineSearchResult>(searchResponse.Content.ReadAsStringAsync().Result);
                if (searchResult.totalCount > 0)
                {
                    returnResult.totalCount = searchResult.totalCount;
                    returnResult.items = searchResult
                                        .items
                                        .Where(r => r.type.Equals("STICKER"))
                                        .Select(r => new SimpleItem
                                        {
                                            id = r.id,
                                            title = r.title,
                                            author = r.authorName,
                                            icon = ConvertImgUrlToImage(r.listIcon.src),
                                            check = false,
                                        })
                                        .OrderBy(r => Convert.ToInt32(r.id))
                                        .ToList();

                    return returnResult;
                }
            }

            return null;
        }

        public List<string> LoadSticker(List<string> stickerIds)
        {
            try
            {
                var picPaths = new List<string>();

                foreach (var stickerId in stickerIds)
                {
                    var zipFilePath = DownloadStickerZip(stickerId);
                    var extractPath = zipFilePath.Split(new[] { ".zip" }, StringSplitOptions.None).First();
                    Unzip(zipFilePath, extractPath);

                    //拿一批貼圖路徑(不要有_key)
                    picPaths.AddRange(new DirectoryInfo(extractPath)
                                      .GetFiles("*.png")
                                      .Where(x => x.FullName.Split('\\').Last().IndexOf("_key@2x.png") >= 0
                                                  && x.FullName.Split('\\').Last().IndexOf("tab_") == -1)
                                      .Select(x => x.FullName)
                                      .ToList());
                }

                return picPaths;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public (bool success, string msg, string setUrl) ConvertPack(List<string> ids, string setName, string setTitle, List<DataGridViewRow> rows)
        {
            var bot = new TelegramBotClient(_botKey);

            if (false == setName.EndsWith($"_by_{_botName}"))
            {
                //依照API DOC 說明 https://core.telegram.org/bots/api#createnewstickerset
                //要以 _by_xxxbot 當作貼圖包name結尾
                setName = $"{setName}_by_{_botName}";
            }
            
            setTitle = $"{setTitle} @EsnChg";
            var addStickerUrl = $"https://t.me/addstickers/{setName}";

            try
            {
                var checkSetName = bot.GetStickerSetAsync(setName).Result;
                SendMessage($"同ID的貼圖包已存在 [<a href=\"{addStickerUrl}\">{setName}</a>]，您可以考慮直接使用，或者重新給一個ID。");
                return (success: false, msg: $"同ID [{setName}] 的貼圖包已存在", setUrl: null);
            }
            catch { }

            try
            {
                #region 先拿第一張圖來建貼圖包

                var picPath = rows[0].Cells[0].Value.ToString().Replace("_key@2x.png", "@2x.png");
                var image = new MagickImage(picPath);
                var ms = new MemoryStream();
                image.VirtualPixelMethod = VirtualPixelMethod.Transparent;
                image.Resize(_stickerWidth, _stickerHeight);
                image.Write(ms, MagickFormat.Png);
                ms.Position = 0;

                //上第一張圖檔
                var firstSticker = new SimpleSticker
                {
                    fileId = bot.UploadStickerFileAsync(userId: _userId, pngSticker: ms).Result.FileId,
                    emojis = rows[0].Cells[2].Value.ToString()
                };

                //創建貼圖包
                var r = bot.CreateNewStickerSetAsync(userId: _userId,
                            name: setName,
                            title: setTitle,
                            pngSticker: firstSticker.fileId,
                            emojis: firstSticker.emojis).Wait(20000);
                var msgId = SendMessage($"已成功建立貼圖包[<a href=\"{addStickerUrl}\">{setTitle}</a>]，剩下的貼圖將慢慢加入，請耐心等候；目前進度1/{rows.Count}。").msgId;

                rows.RemoveAt(0); //成功後移除第一張，下面迴圈剩下的慢慢加入
                #endregion

                #region 加入剩下的

                var idx = 2;
                foreach (var row in rows)
                {
                    picPath = row.Cells[0].Value.ToString().Replace("_key@2x.png", "@2x.png");
                    image = new MagickImage(picPath);
                    ms = new MemoryStream();
                    image.VirtualPixelMethod = VirtualPixelMethod.Transparent;
                    image.Resize(_stickerWidth, _stickerHeight);
                    image.Write(ms, MagickFormat.Png);
                    ms.Position = 0;

                    var sticker = new SimpleSticker
                    {
                        fileId = bot.UploadStickerFileAsync(userId: _userId, pngSticker: ms).Result.FileId,
                        emojis = row.Cells[2].Value.ToString()
                    };

                    Thread.Sleep(20);

                    bot.AddStickerToSetAsync(userId: _userId,
                        name: setName,
                        pngSticker: sticker.fileId,
                        emojis: sticker.emojis).Wait(20000);

                    Thread.Sleep(20);

                    var editResult = EditMessage(msgId, $"已成功建立貼圖包[<a href=\"{addStickerUrl}\">{setTitle}</a>]，剩下的貼圖將慢慢加入，請耐心等候；目前進度{idx}/{rows.Count + 1}。");

                    if (false == editResult.success)
                    {
                        msgId = Convert.ToInt32(editResult.msg);
                    }

                    idx++;
                }

                #endregion

                return (success: true, msg: msgId.ToString(), setUrl: addStickerUrl);
            }
            catch
            {
                return (success: false, msg: $"不知道什麼原因", setUrl: null);
            }
            finally
            {
                try
                {
                    DeleteFolder(new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\')}\\tmp"));
                }
                catch { }
            }

        }

        public (bool success, int msgId) SendMessage(string message)
        {
            var bot = new TelegramBotClient(_botKey);
            var m = bot.SendTextMessageAsync(_userId, message, Telegram.Bot.Types.Enums.ParseMode.Html);

            return (success: true, msgId: m.Result.MessageId);
        }

        public (bool success, string msg) EditMessage(int messageId, string message)
        {
            var bot = new TelegramBotClient(_botKey);
            try
            {
                var r = bot.EditMessageTextAsync(chatId: _userId,
                                                 messageId: messageId,
                                                 text: message,
                                                 parseMode: Telegram.Bot.Types.Enums.ParseMode.Html).Result;

                return (success: true, msg: null);
            }
            catch
            {
                var msgId = SendMessage(message).msgId;
                return (success: false, msg: msgId.ToString());
            }

            
        }

        public (bool success, string msg) CheckBotKey(string key, bool allowEmpty = true)
        {
            if (true == string.IsNullOrWhiteSpace(key))
            {
                if (false == allowEmpty)
                {
                    return (success: false, msg: "Bot Key不可為空，請確實填寫。");
                }
                else
                {
                    return (success: true, msg: string.Empty);
                }
            }

            var keyInt = default(int);
            if (key.Split(':').Length != 2
                || false == int.TryParse(key.Split(':').First(), out keyInt))
            {
                return (success: false, msg: "Bot Key有誤，請重新填寫。");
            }

            return (success: true, msg: string.Empty);
        }

        public (bool success, string msg) CheckBotName(string name, bool allowEmpty = true)
        {
            if (true == string.IsNullOrWhiteSpace(name))
            {
                if (false == allowEmpty)
                {
                    return (success: false, msg: "Bot Name不可為空，請確實填寫。");
                }
                else
                {
                    return (success: true, msg: string.Empty);
                }
            }

            if (name.IndexOf("@@") > -1)
            {
                return (success: false, msg: "Bot Name有誤，請確實填寫。");
            }

            if (false == name.EndsWith("bot")
                || false == name.StartsWith("@")
                || name.Length <= 4)
            {
                return (success: false, msg: "Bot Name 必須以@開頭以及小寫 bot 結尾，請重新填寫。");
            }

            return (success: true, msg: string.Empty);
        }

        public (bool success, string msg) CheckUserId(string id, bool allowEmpty = true)
        {
            if (true == string.IsNullOrWhiteSpace(id))
            {
                if (false == allowEmpty)
                {
                    return (success: false, msg: "User Id不可為空，請確實填寫。");
                }
                else
                {
                    return (success: true, msg: string.Empty);
                }
            }

            var r = default(int);

            if (false == int.TryParse(id, out r))
            {
                return (success: false, msg: "User Id 輸入有誤，請重新填寫。");
            }

            return (success: true, msg: string.Empty);
        }

        private Image ConvertImgUrlToImage(string url)
        {
            var client = new WebClient();
            return Image.FromStream(new MemoryStream(client.DownloadData(url)));
        }

        private string DownloadStickerZip(string id)
        {
            var tmpDirPath = $"{AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\')}\\tmp";
            var zipFilePath = $"{tmpDirPath}\\{id}.zip";

            if (false == Directory.Exists(tmpDirPath))
            {
                Directory.CreateDirectory(tmpDirPath);
            }

            var downloadUrl = _downloadApi.Replace("@ID@", id);
            WebClient wc = new WebClient();
            wc.DownloadFile(downloadUrl, zipFilePath);

            return zipFilePath;
        }

        private void Unzip(string zipFilePath, string extractPath)
        {
            if (Directory.Exists(extractPath))
            {
                DeleteFolder(new DirectoryInfo(extractPath));
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath);
        }

        private void DeleteFolder(DirectoryInfo path)
        {
            foreach (FileInfo file in path.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subdirectory in path.GetDirectories())
            {
                DeleteFolder(subdirectory);
                subdirectory.Delete();
            }

        }

        private Image ResizeIamge(Image img, int width, int height)
        {
            if (img.Width == width && img.Height == height)
            {
                return img;
            }

            var result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            result.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (var g = Graphics.FromImage(result))
            {
                g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }

            return result;
        }
    }
}
