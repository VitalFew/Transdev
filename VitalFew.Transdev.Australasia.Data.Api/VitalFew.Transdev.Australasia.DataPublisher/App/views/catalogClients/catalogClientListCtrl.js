(function () {
    "use strict";
    angular
        .module("app")
        .controller("catalogClientListCtrl",
                    ["$http","catalogResource", CatalogClientListCtrl]);

    function CatalogClientListCtrl($http, catalogResources) {
        var vm = this;
        //TODO: need to get from login
        $http.defaults.headers.common['clientid'] = 'KEAZ';
        $http.defaults.headers.common['clienttoken'] = '123ADDDEEE';
        catalogResources.query(function (data) {
            vm.catalogs = data;
        });
    }
}());
