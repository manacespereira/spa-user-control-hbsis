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
                templateUrl: "./views/newClient.html"
            });

            $routeProvider.when("/editUser/:id", {
                controller: "homeController",
                templateUrl: "./views/home.html"
            });

            $routeProvider.when("/login", {
                controller: "loginController",
                templateUrl: "./views/login.html"
            });

            $routeProvider.when("/signup", {
                controller: "signupController",
                templateUrl: "./views/signup.html"
            });

            $routeProvider.when("/tokens", {
                controller: "tokensManagerController",
                templateUrl: "./views/tokens.html"
            });

            $routeProvider.when("/associate", {
                controller: "associateController",
                templateUrl: "./views/associate.html"
            });

            $routeProvider.otherwise({ redirectTo: "/home" });
        });
})();