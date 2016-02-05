angular.module('altsoft.shopifyImportModule')
.controller('altsoft.shopifyImportModule.virtoStoresController', ['$scope', 'virtoStoresResources', 'platformWebApp.bladeNavigationService', function ($scope, virtoStoresResources, bladeNavigationService) {
    var blade = $scope.blade;
    blade.isLoading = false;

    $scope.storeId = null;

    $scope.refresh = function () {
        blade.isLoading = true;
        virtoStoresResources.stores({}, function (result) {
            blade.isLoading = false;
            $scope.availableStores = result;
        });
    }
    $scope.isValid = function () {
        return $scope.blade.importConfiguration.storeId != null;
    }

    $scope.refresh();

    $scope.save = function() {
        bladeNavigationService.closeBlade(blade);
    }
}]);
