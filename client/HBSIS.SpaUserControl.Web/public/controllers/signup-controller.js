﻿(function() {
    'use strict';
    angular
        .module('spaHbsisApp')
        .controller('signupController', signupController);

    signupController.inject = ['$scope, $location, $timeout, authService'];

    function signupController($scope, $location, $timeout, authService) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.registration = {
            userName: "",
            password: "",
            confirmPassword: ""
        };

        $scope.signUp = function() {

            authService.saveRegistration($scope.registration).then(function(response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = "Usuário registrado com sucesso. Você será redirecionado em 2 segundos.";
                    startTimer();

                },
                function(response) {
                    var errors = [];
                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }
                    $scope.message = "Erro ao registrar usuário:" + errors.join(' ');
                });
        };

        var startTimer = function() {
            var timer = $timeout(function() {
                    $timeout.cancel(timer);
                    $location.path('/login');
                },
                2000);
        };
    };
})();