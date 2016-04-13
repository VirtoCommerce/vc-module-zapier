using System.Collections.Generic;
using Altsoft.ShopifyImportModule.Web.Models.Shopify;

namespace Altsoft.ShopifyImportModule.Web.Interfaces
{
    public interface IShopifyRepository
    {
        #region Public Methods

        IEnumerable<ShopifyProduct> GetShopifyProducts();

        IEnumerable<ShopifyCustomCollection> GetShopifyCollections();

        IEnumerable<ShopifyCollect> GetShopifyCollects();

        IEnumerable<ShopifyTheme> GetShopifyThemes();

        IEnumerable<ShopifyAsset> GetShopifyAssets(long themeId);

        IEnumerable<ShopifyPage> GetShopifyPages();

        ShopifyAsset DownloadShopifyAsset(long themeId, ShopifyAsset asset);

        #endregion
    }
}