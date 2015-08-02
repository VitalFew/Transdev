(function () {
    "use strict";

    angular
        .module("app")
        .controller("catalogEditCtrl",
        ["$stateParams","$http","catalogResource",
            catalogEditCtrl]);

    function catalogEditCtrl($stateParams, $http, catalogResource) {
        var vm = this;
        var catalogId = $stateParams.catalogId;
        //TODO: should get from log in
        $http.defaults.headers.common['clientid'] = 'KEAZ';
        $http.defaults.headers.common['clienttoken'] = '123ADDDEEE';

        catalogResource.get({ id: catalogId }, function (data) {
            vm.catalog = data;
            vm.title = "Catalog Client Name: " + vm.catalog.ClientName;
        });
    }
}());