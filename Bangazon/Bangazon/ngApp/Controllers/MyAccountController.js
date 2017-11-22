app.controller("myAccountController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    let vm = this;

    vm.message = "My Account";
    vm.FName = "";
    vm.LName = "";

    vm.editAccount = function () {
        console.log("in editAccount");
    }

}
]);