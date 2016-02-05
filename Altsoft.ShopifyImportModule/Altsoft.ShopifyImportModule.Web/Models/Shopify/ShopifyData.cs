using System.Collections.Generic;
using System.IO;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    public class ShopifyData
    {
        public IEnumerable<ShopifyProduct> Products { get; set; }
        public IEnumerable<ShopifyPage> Pages{ get; set; }
        public IEnumerable<ShopifyCollect> Collects { get; set; }
        public IEnumerable<ShopifyCustomCollection> Collections { get; set; }
        public Dictionary<ShopifyTheme, Stream> Themes { get; set; } 
    }
}