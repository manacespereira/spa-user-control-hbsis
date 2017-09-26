(function() {
    'use strict';

    angular.module('spaHbsisApp', [
            'ngRoute',
            'LocalStorageModule',
            'ui.utils.masks',
            'angular-loading-bar'
        ])
        .config(function($httpProvider) {
            $httpProvider.interceptors.push('authInterceptorService');
        })
        .run(['authService', function(authService) {
            authService.fillAuthData();
        }]);

})();