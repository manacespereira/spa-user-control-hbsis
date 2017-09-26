(function() {
    'use strict';

    angular.module('spaHbsisApp')
        .config(function($routeProvider, $locationProvider) {
            $locationProvider.html5Mode(true);

            $routeProvider.when("/home", {
                controller: "homeController",
                templateUrl: "./views/home.html"
            });

            $routeProvider.when("/newClient", {
                controller: "homeController",
                templateUrl: "./views/formClient.html"
            });

            $routeProvider.when("/editClient/:id", {
                controller: "homeController",
                templateUrl: "./views/formClient.html"
            });

            $routeProvider.when("/login", {
                controller: "loginController",
                templateUrl: "./views/login.html"
            });

            $routeProvider.when("/tokens", {
                controller: "tokensManagerController",
                templateUrl: "./views/tokens.html"
            });

            $routeProvider.otherwise({ redirectTo: "/home" });
        });
})();