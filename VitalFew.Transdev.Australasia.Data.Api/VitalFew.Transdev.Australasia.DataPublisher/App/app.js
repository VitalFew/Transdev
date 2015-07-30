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
        });
    }]);

}());