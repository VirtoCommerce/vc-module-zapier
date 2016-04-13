using System;
using System.Collections.Generic;
using System.Net;
using Altsoft.ShopifyImportModule.Web.Interfaces;
using Altsoft.ShopifyImportModule.Web.Models.Shopify;
using Newtonsoft.Json;

namespace Altsoft.ShopifyImportModule.Web.Repositories
{
    public class ShopifyRepository : IShopifyRepository
    {
        private readonly IShopifyAuthenticationService _shopifyAuthenticationService;

        public ShopifyRepository(
            IShopifyAuthenticationService shopifyAuthenticationService)
        {
            _shopifyAuthenticationService = shopifyAuthenticationService;
        }

        public IEnumerable<ShopifyProduct> GetShopifyProducts()
        {
            var retVal = new List<ShopifyProduct>();

            long totalCount = 0;
            var requestUrl = GetRequestUrl("products/count.json");
            var cridentials = _shopifyAuthenticationService.GetCridentials();
            using (var webClient = new WebClient())
            {
                webClient.Credentials = cridentials;

                var json = webClient.DownloadString(requestUrl);
                var totalCountObj = JsonConvert.DeserializeObject<ShopifyTotalCount>(json);
                if(totalCountObj != null)
                {
                    totalCount = totalCountObj.Count;
                }
            }
            var limit = 50;
            for(var page = 1; totalCount > 0; page++)
            {
                var result = GetShopifyList<ShopifyProduct, ShopifyProductList>(string.Format("products.json?limit={0}&page={1}", limit, page), list => list.Products);
                retVal.AddRange(result);
                totalCount -= limit;
            }

            return retVal;
        }

        public IEnumerable<ShopifyCustomCollection> GetShopifyCollections()
        {
            var result = GetShopifyList<ShopifyCustomCollection, ShopifyCustomCollectionList>(
                "custom_collections.json", list => list.CustomCollections);
            return result;
        }

        public IEnumerable<ShopifyCollect> GetShopifyCollects()
        {
            var result = GetShopifyList<ShopifyCollect, ShopifyCollectList>("collects.json", list => list.Collects);
            return result;
        }

        public IEnumerable<ShopifyTheme> GetShopifyThemes()
        {
            var result = GetShopifyList<ShopifyTheme, ShopifyThemeList>("themes.json", list => list.Themes);
            return result;
        }

        public IEnumerable<ShopifyPage> GetShopifyPages()
        {
            var result = GetShopifyList<ShopifyPage, ShopifyPageList>("pages.json", list => list.Pages);
            return result;
        }

        public IEnumerable<ShopifyAsset> GetShopifyAssets(long themeId)
        {
            var result = GetShopifyList<ShopifyAsset, ShopifyAssetList>(
                string.Format("themes/{0}/assets.json", themeId), list => list.Assets);
            return result;
        }

        public ShopifyAsset DownloadShopifyAsset(long themeId, ShopifyAsset asset)
        {
            ShopifyAsset downloadedAsset = null;
            var cridentials = _shopifyAuthenticationService.GetCridentials();
            using (var webClient = new WebClient())
            {
                webClient.Credentials = cridentials;
                var url =
                    GetRequestUrl(string.Format("themes/{0}/assets.json?asset[key]={1}&theme_id={0}", themeId,
                        asset.Key));

                var json = webClient.DownloadString(url);
                var downloadedAssetContainer = JsonConvert.DeserializeObject<ShopifyAssetContainer>(json);
                downloadedAsset = downloadedAssetContainer.Asset;
            }

            return downloadedAsset;
        }

        private IEnumerable<TItem> GetShopifyList<TItem,TList>(string endpoint,Func<TList,IEnumerable<TItem>> getCollection)
        {
            var requestUrl = GetRequestUrl(endpoint);
            var cridentials = _shopifyAuthenticationService.GetCridentials();
            using (var webClient = new WebClient())
            {
                webClient.Credentials = cridentials;

                var json = webClient.DownloadString(requestUrl);
                var result = JsonConvert.DeserializeObject<TList>(json);

                return getCollection(result);
            }
        }

        private string GetRequestUrl(string param)
        {
            var shopName = _shopifyAuthenticationService.GetShopName();

            if (string.IsNullOrWhiteSpace(shopName))
                throw new ArgumentException("Shop name is empty!");

            var initialUrl = string.Format("https://{0}.myshopify.com/admin/{1}", shopName, param);
            return initialUrl;
        }

       
    }
}