angular.module('altsoft.shopifyImportModule')
.controller('altsoft.shopifyImportModule.shopifyImportProgressController', ['$scope', 'shopifyImportResources', 'platformWebApp.bladeNavigationService', function ($scope, shopifyImportResources, bladeNavigationService) {
    var blade = $scope.blade;
    blade.isLoading = false;
    blade.title = 'Importing from Shopify';

    $scope.$on("new-notification-event", function (event, notification) {
        if (blade.notification && notification.id == blade.notification.id)
        {
            angular.copy(notification, blade.notification);
        }
    });

    $scope.setForm = function (form) {
        $scope.formScope = form;
    }
  
    $scope.bladeHeadIco = 'fa fa-file-archive-o';
}]);
