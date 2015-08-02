(function () {
    "use strict";

    angular
        .module("app")
        .controller("catalogEditCtrl",
        ["$stateParams", "$http", "$state", "catalogResource",
            catalogEditCtrl]);

    function catalogEditCtrl($stateParams, $http, $state, catalogResource) {
        var vm = this;
        var catalogId = $stateParams.catalogId;
        //TODO: should get from log in
        $http.defaults.headers.common['clientid'] = 'KEAZ';
        $http.defaults.headers.common['clienttoken'] = '123ADDDEEE';

        catalogResource.get({ id: catalogId }, function (data) {
            vm.catalog = data;
            vm.catalog.ClientStatus = vm.catalog.ClientStatus === "Active" ? true : false;
            vm.title = "Catalog Client Name: " + vm.catalog.ClientName;
        });
         
        vm.submit = function (isValid) {
            alert(isValid);
            if (isValid) {
                catalogResource.save(vm.catalog, function (data) {
                    alert(data)
                })
            }
        }

        vm.cancel = function () {
            $state.go('home');
        };
    }
}());