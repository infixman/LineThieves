using LineThieves.Class;
using LineThieves.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineThieves
{
    public partial class EmojiSelector : Form
    {
        public string ReturnValue { get; set; }

        public EmojiSelector()
        {
            InitializeComponent();
        }

        private void EmojiSelector_Load(object sender, EventArgs e)
        {
            var emojiTypes = Emojis.All.Select(x => x.category).Distinct().OrderBy(x => x).ToList();
            cb_EmojiType.DataSource = emojiTypes;
        }

        private void pic_Click(object sender, EventArgs e)
        {
            ReturnValue = UnicodeToString(((PictureBox)sender).Name.Split('_').ToList());
            this.Visible = false;
        }

        private string UnicodeToString(List<string> unicodeString)
        {
            var result = string.Empty;

            foreach (var tmp in unicodeString)
            {
                result += EmojiCodeToUTF16String(tmp);
            }

            return result;
        }

        private string EmojiCodeToUTF16String(string EmojiCode)
        {
            if (EmojiCode.Length != 4 && EmojiCode.Length != 5)
            {
                throw new ArgumentException("错误的 EmojiCode 16进制数据长度.一般为4位或5位");
            }

            //1f604
            int EmojiUnicodeHex = int.Parse(EmojiCode, System.Globalization.NumberStyles.HexNumber);

            //1f604对应 utf16 编码的int
            Int32 EmojiUTF16Hex = EmojiToUTF16(EmojiUnicodeHex, true); //这里字符的低位在前.高位在后.
            var emojiBytes = BitConverter.GetBytes(EmojiUTF16Hex); //把整型值变成Byte[]形式. Int64的话 丢掉高位的空白0000000   

            return Encoding.Unicode.GetString(emojiBytes);
        }

        private Int32 EmojiToUTF16(Int32 V, bool LowHeight = true)
        {
            Int32 Vx = V - 0x10000;
            Int32 Vh = Vx >> 10;//取高10位部分
            Int32 Vl = Vx & 0x3ff; //取低10位部分
            Int32 wh = 0xD800; //結果的前16位元初始值,这个地方应该是根据Unicode的编码规则总结出来的数值.
            Int32 wl = 0xDC00; //結果的後16位元初始值,这个地方应该是根据Unicode的编码规则总结出来的数值.
            wh = wh | Vh;
            wl = wl | Vl;
            if (LowHeight)
            {
                //低位左移16位以后再把高位合并起来 得到的结果是UTF16的编码值   //适合低位在前的操作系统 
                return wl << 16 | wh;
            }
            else
            {
                //高位左移16位以后再把低位合并起来 得到的结果是UTF16的编码值   //适合高位在前的操作系统
                return wh << 16 | wl;
            }
        }

        private void cb_EmojiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnl_EmojiList.Controls.Clear();
            var selectedCategory = cb_EmojiType.SelectedValue.ToString().ToLower();

            if (Emojis.All.Where(x => x.category == selectedCategory).Any())
            {
                var emojis = Emojis.All.Where(x => x.category == selectedCategory
                                              /*&& x.code_points.code_base.Split('-').Count() <= 2*/
                                              && string.IsNullOrWhiteSpace(x.diversity));

                var rm = Resources.ResourceManager;
                var i = 0;

                foreach (var emoji in emojis)
                {
                    var x = (i / 10) * 32;
                    var y = (i % 10) * 32;
                    var codeBase = emoji.code_points.code_base.Replace("-", "_").ToLower();
                    var p = new PictureBox
                    {
                        Name = codeBase,
                        Size = new Size(32, 32),
                        Location = new Point(x, y),
                        Image = (Image)rm.GetObject($"_{codeBase}"),
                    };

                    p.Click += pic_Click;
                    this.pnl_EmojiList.Controls.Add(p);
                    i++;
                }
            }
        }

        private void EmojiSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReturnValue = null;
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
