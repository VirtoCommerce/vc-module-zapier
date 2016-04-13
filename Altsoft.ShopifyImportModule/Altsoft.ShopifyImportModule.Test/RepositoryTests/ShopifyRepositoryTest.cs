using System.Linq;
using Altsoft.ShopifyImportModule.Web.Interfaces;
using Altsoft.ShopifyImportModule.Web.Repositories;
using Altsoft.ShopifyImportModule.Web.Services;
using Moq;
using VirtoCommerce.Platform.Core.Settings;
using Xunit;

namespace Altsoft.ShopifyImportModule.Test.RepositoryTests
{
    
    public class ShopifyRepositoryTest
    {
        [Fact]
        public void GetShopifyCollectsTest()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var collects = repository.GetShopifyCollects();

            Assert.NotNull(collects);
            Assert.True(collects.Any());
        }


        [Fact]
        public void GetShopifyCollectionsTest()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var collections = repository.GetShopifyCollections();

            Assert.NotNull(collections);
            Assert.True(collections.Any());
        }



        [Fact]
        public void GetShopifyProductsTest()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var products = repository.GetShopifyProducts();

            Assert.NotNull(products);
            Assert.True(products.Any());

        }

        [Fact]
        public void GetShopifyPagesTest()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var pages = repository.GetShopifyPages();

            Assert.NotNull(pages);
            Assert.True(pages.Any());

        }

        [Fact]
        public void GetShopifyThemesTest()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var themes = repository.GetShopifyThemes();

            Assert.NotNull(themes);
            Assert.True(themes.Any());

        }

        [Fact]
        public void GetShopifyAssetsTest()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var theme = repository.GetShopifyThemes().First();

            var assets = repository.GetShopifyAssets(theme.Id);

            Assert.NotNull(assets);
            Assert.True(assets.Any());

        }

        [Fact]
        public void GetShopifyThemeZip()
        {
            var shopifyAuthenticationService = GetAuthService();

            var repository = new ShopifyRepository(shopifyAuthenticationService);

            var theme = repository.GetShopifyThemes().First();


        }
        private IShopifyAuthenticationService GetAuthService()
        {
            var settingsManagerMock = GetSettingsServiceMock();
            var settingsManager = settingsManagerMock.Object;
            var shopifyAuthenticationService = new ShopifyAuthenticationService(settingsManager);

            return shopifyAuthenticationService;
        }


        private static Mock<ISettingsManager> GetSettingsServiceMock()
        {
            var settingsServiceMock = new Mock<ISettingsManager>();
            settingsServiceMock.Setup(m => m.GetValue("Altsoft.ShopifyImport.Credentials.APIKey", string.Empty))
                .Returns("d7a2d3db100f5ce3c0e19c8831aaa9f1");

            settingsServiceMock.Setup(m => m.GetValue("Altsoft.ShopifyImport.Credentials.ShopName", string.Empty))
                .Returns("shopify-import-test-shop");

            settingsServiceMock.Setup(m => m.GetValue("Altsoft.ShopifyImport.Credentials.Password", string.Empty))
                .Returns("c64bbf7cd5d3a4cda8f52efe10e82992");
            return settingsServiceMock;
        }
    }
}
