(function() {
    'use strict';

    angular
        .module('spaHbsisApp')
        .controller('indexController', indexController);

    indexController.inject = ['$scope, $location, authService'];

    function indexController($scope, $location, authService) {
        $scope.logOut = function() {
            authService.logOut();
            $location.path('/home');
        };

        $scope.authentication = authService.authentication;
    };
})();