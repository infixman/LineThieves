using System.Collections.Generic;

namespace LineThieves.Class
{
    public class ListIcon
    {
        public string src { get; set; }
        public object width { get; set; }
        public object height { get; set; }
        public object imageId { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string title { get; set; }
        public object description { get; set; }
        public bool newFlag { get; set; }
        public string productUrl { get; set; }
        public ListIcon listIcon { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public object authorId { get; set; }
        public string authorName { get; set; }
        public int priceTier { get; set; }
        public string priceAmount { get; set; }
        public string priceString { get; set; }
        public int version { get; set; }
        public object versionString { get; set; }
        public int validDays { get; set; }
        public bool onSale { get; set; }
        public bool availableForPresent { get; set; }
        public bool availableForPurchase { get; set; }
        public bool bargainFlag { get; set; }
        public string stickerResourceType { get; set; }
        public bool hasAnimation { get; set; }
        public bool hasSound { get; set; }
        public string price { get; set; }
    }

    public class Facet
    {
        public string type { get; set; }
        public int count { get; set; }
        public bool overMax { get; set; }
    }

    public class LineSearchResult
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public List<Facet> facets { get; set; }
    }
}
