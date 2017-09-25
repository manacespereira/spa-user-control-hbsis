(function() {
    'use strict';

    angular.module('spaHbsisApp')
        .factory('authInterceptorService', function($q, $injector, $location, localStorageService, baseConfig) {

            var authInterceptorServiceFactory = {

                request: function(config) {

                    config.headers = config.headers || {};

                    var authData = localStorageService.get('authorizationData');
                    if (authData && config.url.includes(baseConfig.apiUrl))
                        config.headers.Authorization = 'Bearer ' + authData.token;
                    return config;
                },

                responseError: function(rejection) {
                    if (rejection.status === 401) {
                        var authService = $injector.get('authService');
                        var authData = localStorageService.get('authorizationData');

                        if (authData) {
                            if (authData.useRefreshTokens) {
                                $location.path('/refresh');
                                return $q.reject(rejection);
                            }
                        }
                        authService.logOut();
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
            return authInterceptorServiceFactory;
        });
})();