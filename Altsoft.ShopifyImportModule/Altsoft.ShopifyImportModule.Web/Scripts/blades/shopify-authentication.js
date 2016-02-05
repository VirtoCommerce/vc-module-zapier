angular.module('altsoft.shopifyImportModule')
.controller('altsoft.shopifyImportModule.shopifyAuthenticationController', ['$scope', 'shopifyAuthenticationResources', 'platformWebApp.bladeNavigationService', function ($scope, shopifyAuthenticationResources, bladeNavigationService) {
    $scope.apiKey = '';
    $scope.password = '';
    $scope.shopName = '';

    $scope.wrongCridentials = false;
    var initialized = false;
    var blade = $scope.blade;
    blade.isLoading = false;
    blade.title = 'Shopify authentication';
    blade.subtitle = 'Please enter shopify cridentials';
    blade.headIcon = 'shopify-icon';

    $scope.refresh = function () {
        blade.isLoading = true;
        shopifyAuthenticationResources.isAuthenticated({}, function (result) {
            blade.isLoading = false;
            
            if (result.isAuthenticated) {
                $scope.wrongCridentials = false;
                var newBlade = {
                    id: "shopifyImportParams",
                    title: 'Object types selection',
                    subtitle: 'Please choose shopify object types for import',
                    headIcon: 'shopify-icon',
                    template: 'Modules/$(Altsoft.ShopifyImport)/Scripts/blades/shopify-import-params.tpl.html',
                    catalog: blade.catalog,
                    controller: 'altsoft.shopifyImportModule.shopifyImportParamsController'

                };

                bladeNavigationService.showBlade(newBlade, blade.parentBlade);
            } else {
                shopifyAuthenticationResources.getCridentials({}, function (result) {
                    $scope.apiKey = result.apiKey;
                    $scope.password = result.password;
                    $scope.shopName = result.shopName;
                    if (!initialized) {
                        initialized = true;
                        $scope.wrongCridentials = $scope.isValid();
                    } else {
                        $scope.wrongCridentials = true;
                    }
                    
                });
            }
        });
    }

    $scope.isValid = function () {
        return $scope.apiKey && $scope.password && $scope.shopName;
    }

   
    $scope.save = function () {
        $scope.blade.isLoading = false;
        shopifyAuthenticationResources.authenticate({
            apiKey: $scope.apiKey,
            password: $scope.password,
            shopName: $scope.shopName
        }, function () {
            $scope.blade.isLoading = false;
            $scope.refresh();
        });
    }

    $scope.refresh();
}]);
