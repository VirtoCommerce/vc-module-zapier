angular.module('altsoft.shopifyImportModule')
.factory('shopifyImportResources', ['$resource', function ($resource) {
    return $resource('api/shopifyImport/', {}, {
        startImport: { method: 'POST', url: 'api/shopifyImport/start-import/' },
    });
}])
.factory('virtoStoresResources', ['$resource', function ($resource) {
    return $resource('api/stores/', {}, {
        stores: { method: 'GET', url: 'api/stores/' , isArray:true}
    });
}])
.factory('shopifyAuthenticationResources', ['$resource', function ($resource) {
    return $resource('api/shopifyAuthentication/', {}, {
        isAuthenticated: { method: 'GET', url: 'api/shopifyAuthentication/is-authenticated/' },
        getCridentials: { method: 'GET', url: 'api/shopifyAuthentication/get-cridentials' },
        authenticate: { method: 'POST', url: 'api/shopifyAuthentication/authenticate'}
    });
}]);