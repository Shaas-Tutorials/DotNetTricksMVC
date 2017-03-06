angular
    .module("myApp")
    .factory("storeService", ['$http','globalConfig',function (http,global) {
        var url = "";
        debugger;
        console.log(global.apiAddress)
        return {
            getProducts: function () {
                url = global.apiAddress + "/StoreApi";
                return http.get(url);
            },
            getProduct: function (id) {
                url = global.apiAddress + "/StoreApi/"+id;
                return http.get(url);
            },
            saveCart: function (cart) {
                url = global.apiAddress + "/StoreApi";
                return http.post(url,cart);
            }
        }
    }]);