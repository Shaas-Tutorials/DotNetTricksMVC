angular
.module("myApp")
.factory("userService", function ($http, globalConfig) {

    var url = "";
    var obj = {
        getUsers: function () {
            url = globalConfig.apiAddress + "/userapi";
            return $http.get(url);
        },
        getUser: function (id) {
            url = globalConfig.apiAddress + "/userapi/" + id;
            return $http.get(url);
        },
        addUser: function (user) {
            url = globalConfig.apiAddress + "/userapi";
            return $http.post(url, user);
        },
        updateUser: function (user) {
            url = globalConfig.apiAddress + "/userapi/" + user.UserId;
            return $http.put(url, user);
        },
        deleteUser: function (id) {
            url = globalConfig.apiAddress + "/userapi/" + id;
            return $http.delete(url);
        }
    };

    return obj;
});