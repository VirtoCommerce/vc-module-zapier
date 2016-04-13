using Altsoft.ShopifyImportModule.Web.Converters;
using Altsoft.ShopifyImportModule.Web.Interfaces;
using Altsoft.ShopifyImportModule.Web.Repositories;
using Altsoft.ShopifyImportModule.Web.Services;
using Microsoft.Practices.Unity;
using VirtoCommerce.Platform.Core.Modularity;

namespace Altsoft.ShopifyImportModule.Web
{
    public class Module:IModule
    {
        private readonly IUnityContainer _container;
        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public void SetupDatabase()
        {
        }

        public void Initialize()
        {
            _container.RegisterType<IShopifyRepository, ShopifyRepository>();
            _container.RegisterType<IShopifyImportService, ShopifyImportService>();
            _container.RegisterType<IShopifyConverter, ShopifyConverter>();
            _container.RegisterType<IShopifyAuthenticationService, ShopifyAuthenticationService>();
        }

        public void PostInitialize()
        {
        }

        public void Uninstall()
        {
            
        }
    }
}