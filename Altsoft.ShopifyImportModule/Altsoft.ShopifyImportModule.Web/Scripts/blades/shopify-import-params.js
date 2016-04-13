angular.module('altsoft.shopifyImportModule')
.controller('altsoft.shopifyImportModule.shopifyImportParamsController', ['$scope', 'shopifyImportResources', 'platformWebApp.bladeNavigationService', function ($scope, shopifyImportResources, bladeNavigationService) {

    var blade = $scope.blade;
    blade.isLoading = false;

    blade.importConfiguration = {
        virtoCatalogId: blade.catalog.id,
        importProducts: false,
        importCollections: false,
        importCustomers: false,
        importOrders: false,
        importThemes: false,
        importPages: false,
        importBlogs: false,
        storeId:null
    }

    $scope.isValid = function () {
        var importParams = blade.importConfiguration;
        var valid =
            importParams.virtoCatalogId &&
            (importParams.importProducts ||
            importParams.importCollections ||
            importParams.importCustomers ||
            importParams.importOrders ||
            importParams.importPages ||
            importParams.importBlogs ||
            importParams.importThemes);

        if (importParams.importThemes)
            valid = importParams.storeId != null;

        return valid;
    }

    $scope.startImport = function (params) {
        shopifyImportResources.startImport(blade.importConfiguration, function (notification) {
            var newBlade = {
                id: "shopifyImportProgress",
                catalog: blade.catalog,
                notification: notification,
                importParams: blade.importConfiguration,
                headIcon: 'shopify-icon',
                controller: 'altsoft.shopifyImportModule.shopifyImportProgressController',
                template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/shopify-import-progress.tpl.html'
            };

            $scope.$on("new-notification-event", function (event, notification) {
                if (notification && notification.id == newBlade.notification.id) {
                    blade.canImport = notification.finished != null;
                }
            });

            blade.canImport = false;
            bladeNavigationService.showBlade(newBlade, blade.parentBlade);

        }, function (error) {
            bladeNavigationService.setError('Error ' + error.status, $scope.blade);
        });
    }

    var selectStore = function (newValue, oldValue) {
        if (oldValue == newValue)
            return;
        if (newValue) {
            var newBlade = {
                id: "virtoStoresSelection",
                importConfiguration: blade.importConfiguration,
                controller: 'altsoft.shopifyImportModule.virtoStoresController',
                template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/virto-stores.tpl.html',
                title: 'Select store',
                headIcon: 'shopify-icon',
                subtitle: 'Please choose store for theme import'
            };

            bladeNavigationService.showBlade(newBlade, $scope.blade);
        }
    }

    $scope.$watch('blade.importConfiguration.importThemes', selectStore);
    $scope.$watch('blade.importConfiguration.importPages', selectStore);


}]);
