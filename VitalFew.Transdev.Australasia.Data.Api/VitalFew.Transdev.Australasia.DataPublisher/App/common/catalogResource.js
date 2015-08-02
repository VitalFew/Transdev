(function (){
    "use strict"
     
    angular
        .module("common.services")
         .factory("catalogResource", ["$resource", catalogResource])

    function catalogResource($resource) {
        return $resource("/api/catalog/:catalogId");
    }

}());