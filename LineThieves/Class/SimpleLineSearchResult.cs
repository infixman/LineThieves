using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineThieves.Class
{
    public class SimpleLineSearchResult
    {
        public int totalCount { get; set; }
        public List<SimpleItem> items { get; set; }
    }

    public class SimpleItem
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public Image icon { get; set; }
        public bool check { get; set; }
    }
}
