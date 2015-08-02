(function () {
    "use strict";

    var app = angular.module("app",
                            ["common.services", "ui.router"]);

    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/");

        $stateProvider.state("home", {
            url: "/",
            templateUrl: "/App/views/catalogClients/catalogClientList.cshtml",
            controller: "catalogClientListCtrl as vm",
            menu: "Home"
        }).state("catelogDetail", {
            url: "/catalog/:catalogId",
            templateUrl: "/App/views/catalogClients/catalogDetailView.cshtml",
            controller: "catalogDetailCtrl as vm",
            menu: "Detail"
        }).state("catelogEdit", {
            url: "/catalog/edit/:catalogId",
            templateUrl: "/App/views/catalogClients/catalogEditView.cshtml",
            controller: "catalogEditCtrl as vm",
            menu: "Detail"
        });
    }]);

}());