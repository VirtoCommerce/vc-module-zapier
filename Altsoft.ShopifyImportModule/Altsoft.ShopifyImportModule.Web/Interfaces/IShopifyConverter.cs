using Altsoft.ShopifyImportModule.Web.Models;
using Altsoft.ShopifyImportModule.Web.Models.Shopify;
using VirtoCommerce.Content.Data.Models;
using VirtoCommerce.Domain.Catalog.Model;

namespace Altsoft.ShopifyImportModule.Web.Interfaces
{
    public interface IShopifyConverter
    {
        Category Convert(ShopifyCustomCollection category, ShopifyImportParams importParams);
        CatalogProduct Convert(ShopifyProduct category, ShopifyImportParams importParams, ShopifyData shopifyData, VirtoData virtoData);
        Property Convert(ShopifyOption option, ShopifyImportParams importParams);        
    }
}