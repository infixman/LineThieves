using ImageMagick;
using LineThieves.Class;
using LineThieves.Logic;
using LineThieves.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LineThieves
{
    public partial class LineThieves : Form
    {
        private LineThieveLogic _logic;
        private const string _txtSearchPlaceHolder = "請輸入關鍵字";
        private List<string> _sIds = default(List<string>);
        private Dictionary<string,string> _sSets = default(Dictionary<string, string>);
        private int _totalSearchPage = 0;
        private int _nowSearchPage = 0;
        private const int _searchLimit = 40;
        private string _keyWord = string.Empty;
        private Configuration _config;
        private const string _botKeySettingName = "BotKey";
        private const string _botNameSettingName = "BotName";
        private const string _userIdSettingName = "UserId";
        private EmojiSelector _emojiSelector = new EmojiSelector();
        private string _openFolder;

        public LineThieves()
        {
            InitializeComponent();
        }

        private void LineThieves_Load(object sender, EventArgs e)
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            FillTelegramSetting();

            var id = default(int);
            int.TryParse(txt_UserId.Text.Trim(), out id);
            _logic = new LineThieveLogic(id, txt_BotKey.Text.Trim(), txt_BotName.Text.Trim());

            txt_Search.Text = _txtSearchPlaceHolder;
            dg_PickSticker.Columns["dg_PickSticker_Col_Emoji"].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 30f);

            txt_Search.Focus();
            _emojiSelector.VisibleChanged += formVisibleChanged;

            _openFolder = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

            this.Text = $"LineThieves v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".0.0", "")} by Telegram: @EsnChg";
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            _sIds = null;
            _sSets = null;
            txt_Page.Text = "?/?";
            lb_TotalCount.Text = "共?筆";
            lb_TotleStickerCount.Text = "共選?張";
            dg_PickSticker.Rows.Clear();

            _keyWord = txt_Search.Text.Trim();
            if (string.IsNullOrWhiteSpace(_keyWord))
                return;

            dg_SearchResult.Rows.Clear();
            var searchResult = _logic.SearchLineSticker(_keyWord, _searchLimit, _nowSearchPage);
            if (null == searchResult)
            {
                lb_TotalCount.Text = "共0筆";
                txt_Page.Text = "0/0";
                return;
            }

            _nowSearchPage = 0;
            _totalSearchPage = searchResult.totalCount / _searchLimit;
            lb_TotalCount.Text = $"共{searchResult.totalCount}筆";

            //有餘數的話，頁數+1
            if ((searchResult.totalCount - (_totalSearchPage * _searchLimit)) > 0)
            {
                _totalSearchPage++;
            }

            ShowSearchResult(searchResult);
        }

        private void dg_SearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dg_SearchResult.Columns["dg_Search_Col_Check"].Index)
            {
                dg_SearchResult[e.ColumnIndex, e.RowIndex].Value = !(bool)dg_SearchResult[e.ColumnIndex, e.RowIndex].Value;

                if (null == _sSets)
                {
                    _sSets = new Dictionary<string, string>();
                }

                if (true == (bool)dg_SearchResult[e.ColumnIndex, e.RowIndex].Value)
                {
                    if (false == _sSets.ContainsKey(dg_SearchResult.Rows[e.RowIndex].Cells["dg_Search_Col_Id"].Value.ToString()))
                    {
                        _sSets.Add(dg_SearchResult.Rows[e.RowIndex].Cells["dg_Search_Col_Id"].Value.ToString(), 
                                   dg_SearchResult.Rows[e.RowIndex].Cells["dg_Search_Col_Title"].Value.ToString());
                    }
                }
                else
                {
                    if (true == _sSets.ContainsKey(dg_SearchResult.Rows[e.RowIndex].Cells["dg_Search_Col_Id"].Value.ToString()))
                    {
                        _sSets.Remove(dg_SearchResult.Rows[e.RowIndex].Cells["dg_Search_Col_Id"].Value.ToString());
                    }
                }

                if (null == _sIds)
                {
                    _sIds = new List<string>();
                }

                _sIds.Clear();
                _sIds = _sSets.Select(x => x.Key).ToList();
            }
        }

        private void txt_Search_Enter(object sender, EventArgs e)
        {
            if (txt_Search.Text == _txtSearchPlaceHolder)
            {
                txt_Search.Text = string.Empty;
                txt_Search.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txt_Search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search.Text))
            {
                txt_Search.Text = _txtSearchPlaceHolder;
                txt_Search.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btn_SelectAllSticker_Click(object sender, EventArgs e)
        {
            var newCheckStatus = true;
            if (GetPickedSticker().Any())
            {
                newCheckStatus = false;
            }

            foreach (DataGridViewRow row in dg_PickSticker.Rows)
            {
                row.Cells[3].Value = newCheckStatus;
            }

            lb_TotleStickerCount.Text = $"共選{GetPickedSticker().Count}張";
        }

        private void ShowStickerResult(string name, string firstId, List<string> stickerPaths)
        {
            dg_PickSticker.Rows.Clear();
            dg_PickSticker.RowTemplate.Height = 140;
            dg_PickSticker.Columns[1].Width = 150;
            dg_PickSticker.RowHeadersWidth = 75;

            foreach (var stickerPath in stickerPaths)
            {
                dg_PickSticker.Rows.Add(stickerPath, Image.FromStream(new MemoryStream(File.ReadAllBytes(stickerPath))), "😀", false);
            }

            foreach (DataGridViewRow row in dg_PickSticker.Rows)
            {
                row.HeaderCell.Value = $"{row.Index + 1}";
            }

            tab_Main.SelectedIndex = 1;
            txt_SetTitle.Text = name;
            txt_SetName.Text = $"Line{firstId}";
        }

        private void ShowSearchResult(SimpleLineSearchResult searchResult)
        {
            try
            {
                dg_SearchResult.Rows.Clear();
                dg_SearchResult.CellClick -= dg_SearchResult_CellClick;
            }
            catch { }

            var source = new BindingSource();
            source.DataSource = searchResult.items;
            dg_SearchResult.RowTemplate.Height = 130;
            dg_SearchResult.DataSource = source;
            dg_SearchResult.Columns[0].Name = "dg_Search_Col_Id";
            dg_SearchResult.Columns[0].HeaderText = "Id";

            dg_SearchResult.Columns[1].Name = "dg_Search_Col_Title";
            dg_SearchResult.Columns[1].HeaderText = "Title";
            dg_SearchResult.Columns[1].Width = 200;

            dg_SearchResult.Columns[2].Name = "dg_Search_Col_Author";
            dg_SearchResult.Columns[2].HeaderText = "Author";

            dg_SearchResult.Columns[3].Name = "dg_Search_Col_Icon";
            dg_SearchResult.Columns[3].HeaderText = "Icon";
            dg_SearchResult.Columns[3].Width = 130;

            dg_SearchResult.Columns[4].Name = "dg_Search_Col_Check";
            dg_SearchResult.Columns[4].HeaderText = "我要這個";
            dg_SearchResult.Columns[4].Width = 130;

            dg_SearchResult.CellClick += dg_SearchResult_CellClick;
            txt_Page.Text = $"{_nowSearchPage + 1}/{_totalSearchPage}";

            if (_sIds != null && _sIds.Any())
            {
                foreach (DataGridViewRow row in dg_SearchResult.Rows)
                {
                    if (_sIds.Contains(row.Cells["dg_Search_Col_Id"].Value.ToString()))
                    {
                        row.Cells["dg_Search_Col_Check"].Value = true;
                    }
                }
            }
        }

        private void btn_ConvertSet_Click(object sender, EventArgs e)
        {
            var r = _logic.CheckBotKey(txt_BotKey.Text.Trim(), false);
            if (false == r.success)
            {
                MessageBox.Show(r.msg, "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var r2 = _logic.CheckBotName(txt_BotName.Text.Trim(), false);
            if (false == r2.success)
            {
                MessageBox.Show(r2.msg, "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var r3 = _logic.CheckUserId(txt_UserId.Text.Trim(), false);
            if (false == r3.success)
            {
                MessageBox.Show(r3.msg, "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EmojiEmpty())
            {
                MessageBox.Show("Emoji為必填，請確認都已填妥", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var picked = GetPickedSticker();
            if (false == picked.Any())
            {
                MessageBox.Show("請選擇要上傳的貼圖", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (picked.Count() > 120)
            {
                MessageBox.Show("每套貼圖最多120張，請減少數量", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var setNameEnd = $"_by_{txt_BotName.Text.Trim().Replace("@", string.Empty)}";
            if (false == txt_SetName.Text.Trim().EndsWith(setNameEnd))
            {
                var limitLen = (64 - setNameEnd.Length);
                if (txt_SetName.Text.Trim().Length > limitLen)
                {
                    MessageBox.Show($"貼圖包ID長度只能{limitLen}字元，請修改", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (txt_SetName.Text.Trim().Length > 64)
                {
                    MessageBox.Show($"貼圖包ID長度只能64字元，請修改", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //接受英文字母、數字、底線，不能以底線跟數字開頭，不能以底線結尾
            Regex regex = new Regex("^(?![0-9_])(?!.*?_$)[a-zA-Z0-9_]+$");
            if (false == regex.IsMatch(txt_SetName.Text.Trim()))
            {
                MessageBox.Show($"貼圖包ID只接受 [英文字母、數字、底線]，不能以 [底線、數字] 開頭，不能以 [底線] 結尾，請修改", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if ($"{txt_SetName.Text.Trim()}{setNameEnd}".IndexOf("__") > -1)
                {
                    MessageBox.Show($"貼圖包ID不接受連續底線，請修改", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 64 - " @EsnChg".Length = 56
            if (txt_SetTitle.Text.Trim().Length > 56)
            {
                MessageBox.Show($"貼圖包名稱長度只能56字元，請修改", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var convertResult = _logic.ConvertPack(_sIds, txt_SetName.Text.Trim(), txt_SetTitle.Text.Trim(), picked);

            if (false == convertResult.success)
            {
                MessageBox.Show($"因為{convertResult.msg}，所以轉換失敗囉!", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var msg = $"貼圖包 [<a href=\"{convertResult.setUrl}\">{txt_SetTitle.Text.Trim()} @EsnChg</a>] 已轉換完成，欲管理貼圖請至 @Stickers 操作！";

            _logic.SendMessage(msg);
            MessageBox.Show("轉換成功!", "安安", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<DataGridViewRow> GetPickedSticker()
        {
            return dg_PickSticker.Rows
                  .Cast<DataGridViewRow>()
                  .Where(x => (bool)x.Cells["dg_PickSticker_Col_Pick"].Value == true)
                  .ToList();
        }

        private bool EmojiEmpty()
        {
            return dg_PickSticker.Rows
                  .Cast<DataGridViewRow>()
                  .Where(x => string.IsNullOrWhiteSpace(x.Cells["dg_PickSticker_Col_Emoji"].Value.ToString()))
                  .Any();
        }

        private void txt_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //enter
            {
                btn_Search.PerformClick();
            }
        }

        private void txt_BotName_Leave(object sender, EventArgs e)
        {
            var ckeckResult = _logic.CheckBotName(txt_BotName.Text.Trim());

            if (false == ckeckResult.success)
            {
                tab_Main.SelectedIndex = 2;
                txt_BotName.Text = string.Empty;
                txt_BotName.Focus();
                SetSetting(_botNameSettingName, txt_BotName.Text.Trim());
                MessageBox.Show(ckeckResult.msg, "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetSetting(_botNameSettingName, txt_BotName.Text.Trim());
            _logic = new LineThieveLogic(GetIdFromTextbox(), txt_BotKey.Text.Trim(), txt_BotName.Text.Trim());
        }

        private void txt_BotKey_Leave(object sender, EventArgs e)
        {
            var ckeckResult = _logic.CheckBotKey(txt_BotKey.Text.Trim());

            if (false == ckeckResult.success)
            {
                tab_Main.SelectedIndex = 2;
                txt_BotKey.Text = string.Empty;
                txt_BotKey.Focus();
                SetSetting(_botKeySettingName, txt_BotKey.Text.Trim());
                MessageBox.Show(ckeckResult.msg, "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetSetting(_botKeySettingName, txt_BotKey.Text.Trim());
            _logic = new LineThieveLogic(GetIdFromTextbox(), txt_BotKey.Text.Trim(), txt_BotName.Text.Trim());
        }

        private void txt_UserId_Leave(object sender, EventArgs e)
        {
            var ckeckResult = _logic.CheckUserId(txt_UserId.Text.Trim());

            if (false == ckeckResult.success)
            {
                tab_Main.SelectedIndex = 2;
                txt_UserId.Text = string.Empty;
                txt_UserId.Focus();
                SetSetting(_userIdSettingName, txt_UserId.Text.Trim());
                MessageBox.Show(ckeckResult.msg, "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetSetting(_userIdSettingName, txt_UserId.Text.Trim());
            _logic = new LineThieveLogic(GetIdFromTextbox(), txt_BotKey.Text.Trim(), txt_BotName.Text.Trim());
        }

        private void btn_PageBack_Click(object sender, EventArgs e)
        {
            if (_nowSearchPage > 0)
                _nowSearchPage--;
            ShowSearchResult(_logic.SearchLineSticker(_keyWord, _searchLimit, _nowSearchPage));
        }

        private void btn_PageNext_Click(object sender, EventArgs e)
        {
            if ((_nowSearchPage + 1) < _totalSearchPage)
                _nowSearchPage++;
            ShowSearchResult(_logic.SearchLineSticker(_keyWord, _searchLimit, _nowSearchPage));
        }

        private void btn_PageToBegin_Click(object sender, EventArgs e)
        {
            _nowSearchPage = 0;
            ShowSearchResult(_logic.SearchLineSticker(_keyWord, _searchLimit, _nowSearchPage));
        }

        private void btn_PageToEnd_Click(object sender, EventArgs e)
        {
            _nowSearchPage = _totalSearchPage - 1;
            ShowSearchResult(_logic.SearchLineSticker(_keyWord, _searchLimit, _nowSearchPage));
        }

        private void SetSetting(string key, string value)
        {
            if (_config.AppSettings.Settings.AllKeys.Contains(key))
            {
                _config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                _config.AppSettings.Settings.Add(key, value);
            }
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private string GetSetting(string key)
        {
            if (!_config.AppSettings.Settings.AllKeys.Contains(key))
            {
                SetSetting(key, string.Empty);
            }

            return _config.AppSettings.Settings[key].Value;
        }

        private void FillTelegramSetting()
        {
            txt_BotKey.Text = GetSetting(_botKeySettingName);
            txt_BotName.Text = GetSetting(_botNameSettingName);
            txt_UserId.Text = GetSetting(_userIdSettingName);
        }

        private int GetIdFromTextbox()
        {
            var id = 0;
            if (false == string.IsNullOrWhiteSpace(txt_UserId.Text))
            {
                id = Convert.ToInt32(txt_UserId.Text.Trim());
            }

            return id;
        }

        private void btn_SelectSetOk_Click(object sender, EventArgs e)
        {   
            if (_sIds != null && _sIds.Count > 0)
            {   
                ShowStickerResult(_sSets[_sIds[0]], _sIds[0], _logic.LoadSticker(_sIds));
            }
            else
            {
                MessageBox.Show("你沒有勾選任何貼圖，我不知道你要哪一套", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DataGridViewRow> GridSearchSelectedRows()
        {
            return dg_SearchResult.Rows
                  .Cast<DataGridViewRow>()
                  .Where(x => (bool)x.Cells["dg_Search_Col_Check"].Value == true)
                  .ToList();
        }

        private void btn_SelectAllSet_Click(object sender, EventArgs e)
        {
            var newCheckStatus = true;
            if (GridSearchSelectedRows().Any())
            {
                newCheckStatus = false;
            }

            if (null == _sSets)
            {
                _sSets = new Dictionary<string, string>();
            }

            foreach (DataGridViewRow row in dg_SearchResult.Rows)
            {
                row.Cells["dg_Search_Col_Check"].Value = newCheckStatus;

                if (true == newCheckStatus)
                {
                    if (false == _sSets.ContainsKey(row.Cells["dg_Search_Col_Id"].Value.ToString()))
                    {
                        _sSets.Add(row.Cells["dg_Search_Col_Id"].Value.ToString(),
                                   row.Cells["dg_Search_Col_Title"].Value.ToString());
                    }
                }
                else
                {
                    if (true == _sSets.ContainsKey(row.Cells["dg_Search_Col_Id"].Value.ToString()))
                    {
                        _sSets.Remove(row.Cells["dg_Search_Col_Id"].Value.ToString());
                    }
                }
            }

            if (null == _sIds)
            {
                _sIds = new List<string>();
            }

            _sIds.Clear();
            _sIds = _sSets.Select(x => x.Key).ToList();
        }
        
        private void dg_PickSticker_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dg_PickSticker.IsCurrentCellDirty)
            {
                dg_PickSticker.CommitEdit(DataGridViewDataErrorContexts.Commit);

                if (dg_PickSticker.CurrentCell.ColumnIndex == dg_PickSticker.Columns["dg_PickSticker_Col_Pick"].Index)
                {
                    lb_TotleStickerCount.Text = $"共選{GetPickedSticker().Count}張";
                }
            }
        }

        private void btn_AddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "請選擇圖片(可多選)";
            dialog.InitialDirectory = _openFolder;
            dialog.Filter = "PNG (*.*)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (false == dialog.FileNames.Any())
                {
                    MessageBox.Show("你沒有選半張圖啊，加個胗?", "錯囉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _openFolder = Path.GetDirectoryName(dialog.FileNames.First());

                dg_PickSticker.RowTemplate.Height = 140;
                dg_PickSticker.Columns[1].Width = 150;

                foreach (var file in dialog.FileNames)
                {
                    var image = new MagickImage(file);
                    var ms = new MemoryStream();
                    image.VirtualPixelMethod = VirtualPixelMethod.Transparent;
                    image.Resize(140, 140);
                    image.Write(ms, MagickFormat.Png);
                    ms.Position = 0;

                    dg_PickSticker.Rows.Add(file, Image.FromStream(ms), "😀", false);
                }
            }
        }

        private void dg_PickSticker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dg_PickSticker.Columns["dg_PickSticker_Col_Emoji"].Index)
            {
                this.Enabled = false;
                _emojiSelector.Show();
            }                
        }

        private void formVisibleChanged(object sender, EventArgs e)
        {
            if (false == _emojiSelector.Visible)
            {
                dg_PickSticker.CurrentCell.Value = _emojiSelector.ReturnValue;
                this.Enabled = true;
            }
        }

        private void btn_ClearSearch_Click(object sender, EventArgs e)
        {
            dg_SearchResult.Rows.Clear();
            lb_TotalCount.Text = "共?筆";
            txt_Page.Text = "?/?";
            txt_Search.Text = "";
            txt_Search.Focus();
            _sIds = null;
            _sSets = null;
        }

        private void btn_ClearSticker_Click(object sender, EventArgs e)
        {
            dg_PickSticker.Rows.Clear();
            txt_SetName.Text = "";
            txt_SetTitle.Text = "";
            lb_TotleStickerCount.Text = "共選?張";
            txt_SetName.Focus();
        }
    }
}
