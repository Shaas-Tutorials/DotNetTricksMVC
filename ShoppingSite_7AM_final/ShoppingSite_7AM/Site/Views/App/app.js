

angular
    .module("myApp", ["ui.router"])
    .config(['$stateProvider', '$urlRouterProvider', function (statePrd, urlPrd) {
        urlPrd.otherwise("/");
        debugger;
        statePrd
            .state("home", {
                url: "/",
                templateUrl: "Views/App/views/store.html",
                controller: "storeCtrl"
            })
            .state("product", {
                url: "/product/:id",
                templateUrl: "Views/app/views/product.html",
                controller: "storeCtrl"
            })
            .state("cart", {
                url: "/cart",
                templateUrl: "Views/app/views/cart.html",
                controller: "storeCtrl"
            });
    }])
    .constant("globalConfig", {
        apiAddress: 'http://localhost/WebAPI/api'
    });

