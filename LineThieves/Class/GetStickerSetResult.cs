using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineThieves.Class
{
    public class Thumb
    {
        public string file_id { get; set; }
        public int file_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Sticker
    {
        public int width { get; set; }
        public int height { get; set; }
        public string emoji { get; set; }
        public string set_name { get; set; }
        public Thumb thumb { get; set; }
        public string file_id { get; set; }
        public int file_size { get; set; }
    }

    public class StickerSet
    {
        public string name { get; set; }
        public string title { get; set; }
        public bool contains_masks { get; set; }
        public List<Sticker> stickers { get; set; }
    }

    public class GetStickerSetResult
    {
        public bool ok { get; set; }
        public int? error_code { get; set; }
        public string description { get; set; }
        public StickerSet result { get; set; }
    }
}
