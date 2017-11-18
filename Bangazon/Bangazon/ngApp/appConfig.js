app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "/ngApp/Views/home.html",
            controller: "homeController"
        });
}]);