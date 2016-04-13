using Altsoft.ShopifyImportModule.Web.Models;

namespace Altsoft.ShopifyImportModule.Web.Interfaces
{
    public interface IShopifyImportService
    {
        ShopifyImportNotification Import(ShopifyImportParams importParams, ShopifyImportNotification notification);
    }
}