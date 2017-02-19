angular
    .module("myApp", ["ui.router"])
    .config(['$stateProvider', '$urlRouterProvider', function (statePrd, urlPrd) {
        urlPrd.otherwise("/");

        statePrd
            .state("home", {
                url: "/",
                templateUrl: "/views/app/views/store.html",
                controller: "storeCtrl"
            })
            .state("product", {
                url: "/product/:id",
                templateUrl: "/views/app/views/product.html",
                controller: "storeCtrl"
            })
            .state("cart", {
                url: "/cart",
                templateUrl: "/views/app/views/cart.html",
                controller: "storeCtrl"
            });
    }])
    .constant("globalConfig", {
        apiAddress: 'http://localhost:1210/api'
    });