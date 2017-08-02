'use strict';
app.factory('productsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var productsServiceFactory = {};

    var _getProducts = function () {

        return $http.get(serviceBase + 'api/products').then(function (results) {
            return results;
        });
    };

    productsServiceFactory.getProducts = _getProducts;

    return productsServiceFactory;
}]);