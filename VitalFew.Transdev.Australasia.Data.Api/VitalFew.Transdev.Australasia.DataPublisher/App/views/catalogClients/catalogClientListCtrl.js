(function () {
    "use strict";
    angular
        .module("app")
        .controller("catalogClientList",
                     CatalogClientListCtrl);

    function CatalogClientListCtrl() {
        var vm = this;

        vm.catalogs = [
        {
            "clientId": "BC5805F9-8AC8-447B-90E9-5B906B4C1B66",
            "clientName": "KEAZ",
            "clientToken": "123ADDDEEE",
            "clientStatus": "1"
        },
        {
            "clientId": "BC5805F9-8AC8-447B-90E9-5B906B4C1B67",
            "clientName": "Leaf Rake",
            "clientToken": "GDN0011",
            "clientStatus": "1"
        },
         {
             "clientId": "BC5805F9-8AC8-447B-90E9-5B906B4C1B67",
             "clientName": "Rake",
             "clientToken": "GDB0011",
             "clientStatus": "1"
         },
         {
             "clientId": "BC5805F9-8AC8-447B-90E9-5B906B4C1B67",
             "clientName": "Rake",
             "clientToken": "GDB0011",
             "clientStatus": "1"
         },
         {
             "clientId": "BC5805F9-8AC8-447B-90E9-5B906B4C1B67",
             "clientName": "Rake",
             "clientToken": "GDB0011",
             "clientStatus": "1"
         }
        ];
    }
}());
