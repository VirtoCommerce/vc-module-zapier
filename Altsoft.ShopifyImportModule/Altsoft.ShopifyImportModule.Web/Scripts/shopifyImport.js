//Call this to register our module to main application
var moduleTemplateName = "altsoft.shopifyImportModule";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleTemplateName);
}

angular.module(moduleTemplateName,[])
.run(
  ['$rootScope', '$state', 'platformWebApp.pushNotificationTemplateResolver', 'virtoCommerce.catalogModule.catalogImportService', 'platformWebApp.bladeNavigationService', function ($rootScope, $state, notificationTemplateResolver, catalogImportService, bladeNavigationService) {
      //Notifications

      //Import
      var menuImportTemplate =
		{
		    priority: 900,
		    satisfy: function (notify, place) { return place == 'menu' && notify.notifyType == 'CatalogShopifyImport'; },
		    template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/notifications/menuImport.tpl.html',
		    action: function (notify) { $state.go('notificationsHistory', notify) }
		};
      notificationTemplateResolver.register(menuImportTemplate);

      var historyImportTemplate =
		{
		    priority: 900,
		    satisfy: function (notify, place) { return place == 'history' && notify.notifyType == 'CatalogShopifyImport'; },
		    template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/notifications/historyImport.tpl.html',
		    action: function (notify) {
		        var blade = {
		            id: 'CatalogShopifyImportDetail',
		            title: 'shopify import detail',
		            subtitle: 'detail',
		            template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/shopify-import-progress.tpl.html',
		            controller: 'altsoft.shopifyImportModule.shopifyImportProgressController',
		            notification: notify
		        };
		        bladeNavigationService.showBlade(blade);
		    }
		};
      notificationTemplateResolver.register(historyImportTemplate);

      //Import module registring 
      catalogImportService.register({
          name: 'Shopify import',
          description: 'Native catalog data import from Shopify',
          icon: 'fa shopify-icon',
          template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/shopify-authentication.tpl.html'
      });

  }]);

