angular
    .module("myApp")
    .controller("storeCtrl", ['storeService', '$scope', '$rootScope', '$state', '$stateParams', function (storeService, $scope, $rootScope, $state, $stateParams) {
        $rootScope.cart = new shoppingCart("myCart");

        if ($state.current.name == "home") {
            $rootScope.Title = "Store";
            storeService.getProducts().success(function (data) {
                $scope.products = data;
            });
        }
        else if ($state.current.name == "product") {
            $rootScope.Title = "Product";
            var id = $stateParams.id;
            storeService.getProduct(id).success(function (data) {
                $scope.product = data;
            });
        }
        else if ($state.current.name == "cart") {
            $rootScope.Title = "Cart";
        }
    }]);