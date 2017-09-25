(function() {
    'use strict';
    angular
        .module('spaHbsisApp')
        .controller('loginController', loginController);

    loginController.inject = ['$scope, $location, authService, baseConfig'];

    function loginController($scope, $location, authService, baseConfig) {

        $scope.loginData = {
            userName: "",
            password: "",
            useRefreshTokens: false
        };

        $scope.message = "";

        $scope.login = function() {

            authService.login($scope.loginData)
                .then(function(response) {
                        $location.path('/home');
                    },
                    function(err) {
                        $scope.message = err.error_description;
                    });
        };
    }

})();