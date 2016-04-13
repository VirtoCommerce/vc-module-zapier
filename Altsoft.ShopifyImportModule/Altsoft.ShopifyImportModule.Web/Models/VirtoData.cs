using System.Collections.Generic;
using System.IO;
using Altsoft.ShopifyImportModule.Web.Models.Shopify;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Content.Data.Models;

namespace Altsoft.ShopifyImportModule.Web.Models
{
    public class VirtoData
    {
        public List<CatalogProduct> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Dictionary<ShopifyTheme, Stream> Themes { get; set; }
        public List<Property> Properties{ get; set; }
        public List<ShopifyPage> Pages { get; set; }
    }
}