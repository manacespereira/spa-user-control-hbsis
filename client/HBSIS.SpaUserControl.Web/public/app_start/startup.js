(function() {
    'use strict';

    angular.module('spaHbsisApp', [
            'ngRoute',
            'LocalStorageModule',
            'ui.utils.masks'
        ])
        .config(function($httpProvider) {
            $httpProvider.interceptors.push('authInterceptorService');
        })
        .run(['authService', function(authService) {
            authService.fillAuthData();
        }]);

})();