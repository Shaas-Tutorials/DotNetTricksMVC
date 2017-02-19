angular
          .module("myApp", [])
          .controller("ctrl", function ($scope, $rootScope) {
              $rootScope.Title = "Angular App";

              var Address = "Noida";
              $scope.Name = "Shailendra";

              $scope.SayHi = function () {
                  $scope.Message = "Hi AngularJS";
              }
          });

angular
    .module("myApp2", [])
    .controller("ctrl2", function ($scope) {
        $scope.Message = "Controller2";
    });

//angular.element() ===$()===jQuery()
angular.element(document).ready(function () {
    //angular.bootstrap(document, ["myApp"]);

    var div = document.getElementById("container");
    angular.bootstrap(div, ["myApp", "myApp2"]);
});
