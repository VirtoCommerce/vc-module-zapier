namespace Altsoft.ShopifyImportModule.Web.Models
{
    public class ShopifyImportParams
    {
        public string VirtoCatalogId { get; set; }

        public bool ImportProducts { get; set; }

        public bool ImportCollections { get; set; }

        public bool ImportCustomers { get; set; }

        public bool ImportOrders { get; set; }

        public bool ImportThemes { get; set; }

        public bool ImportPages { get; set; }

        public bool ImportBlogs { get; set; }

        public string StoreId { get; set; }
    }
}