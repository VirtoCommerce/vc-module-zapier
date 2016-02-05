using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Altsoft.ShopifyImportModule.Web.Interfaces;
using Altsoft.ShopifyImportModule.Web.Models;
using Hangfire;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.PushNotifications;

namespace Altsoft.ShopifyImportModule.Web.Controllers.Api
{
    [RoutePrefix("api/shopifyImport")]
    public class ShopifyImportController : ApiController
    {
        private readonly IPushNotificationManager _notifier;
        private readonly IShopifyImportService _shopifyImportService;
        private readonly IStoreService _storeService;
        public ShopifyImportController(IPushNotificationManager notifier, IShopifyImportService shopifyImportService, IStoreService storeService)
        {
            _notifier = notifier;
            _shopifyImportService = shopifyImportService;
            _storeService = storeService;
        }

        [HttpPost]
        [ResponseType(typeof(ShopifyImportNotification))]
        [Route("start-import")]
        public IHttpActionResult StartImport(ShopifyImportParams importParams)
        {
            var notification = new ShopifyImportNotification(CurrentPrincipal.GetCurrentUserName())
            {
                Title = "Import catalog from Shopify",
                Description = "starting import...."
            };
            _notifier.Upsert(notification);

            BackgroundJob.Enqueue(() => _shopifyImportService.Import(importParams, notification));

            return Ok(notification);
        }
    }
}