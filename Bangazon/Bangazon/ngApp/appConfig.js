﻿app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "/ngApp/Views/home.html",
            controller: "homeController",
            controllerAs: 'vm'
        })
        .when("/login",
        {
            templateUrl: "/ngApp/Views/login.html",
            controller: "loginController",
            controllerAs: 'vm'
        })
        .when("/mySettings/account",
        {
            templateUrl: "/ngApp/Views/myAccount.html",
            controller: "myAccountController",
            controllerAs: 'vm'
        })
        .when("/mySettings/paymentOptions",
        {

        })
        .when("/mySettings/orderHistory",
        {

        })
        .when("/mySettings/orderHistory/orderDetail",
        {

        })
        .when("/sellProduct",
        {

        })
        .when("/productDetail",
        {

        })
        .when("/productCategories",
        {

        })
        .when("/openOrder",
        {

        })
        .when("/myProducts", {

        })
        .when("/recommendations",
        {

        })
        .when("/wishList",
        {

        })
        .when("favorites", {

        })
        .when("mainPage", {

        });
}]);

app.run(["$rootScope", "$http", "$location", function ($rootScope, $http, $location) {

    $rootScope.isLoggedIn = function () { return !!sessionStorage.getItem("token") }

    $rootScope.$on("$routeChangeStart", function (event, currRoute) {
        var anonymousPage = false;
        var originalPath = currRoute.originalPath;

        if (originalPath) {
            anonymousPage = originalPath.indexOf("/login") !== -1;
        }

        if (!anonymousPage && !$rootScope.isLoggedIn()) {
            event.preventDefault();
            $location.path("/login");
        }
    });

    var token = sessionStorage.getItem("token");

    if (token)
        $http.defaults.headers.common["Authorization"] = `bearer ${token}`;
}])