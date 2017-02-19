angular
.module("myApp")
.controller("userController", function ($scope, $rootScope, userService, $state, $stateParams) {
    if ($state.current.name == "home") {
        $rootScope.Title = "User Listing";

        userService.getUsers().success(function (data) {
            $scope.users = data;
        });
    }
    else if ($state.current.name == "create") {
        $rootScope.Title = "Create User";
    }
    else if ($state.current.name == "edit") {
        $rootScope.Title = "Edit User";
        var id = $stateParams.id;
        userService.getUser(id).success(function (data) {
            $scope.user = data;
        });
    }

    $scope.saveData = function (user) {
        if ($scope.userForm.$valid) {
            if (user.UserId > 0) {
                userService.updateUser(user).success(function (data) {
                    if (data == "updated") {
                        $state.go("home");
                    }
                });
            }
            else {
                userService.addUser(user).success(function (data) {
                    if (data == "created") {
                        $state.go("home");
                    }
                });
            }
        }
    };

    $scope.delete = function (id) {
        if (confirm('Are you sure to delete?')) {
            userService.deleteUser(id).success(function (data) {
                if (data == true) {
                    $state.go("home", {}, { reload: true });
                }
            });
        }
    }
});