(function() {

    'use strict';
    angular.module('spaHbsisApp')
        .factory('tokensManagerService', function($http, baseConfig) {

            var serviceBase = baseConfig.apiUrl;

            var tokenManagerServiceFactory = {};

            var _getRefreshTokens = function() {

                return $http.get(serviceBase + 'api/refreshtokens').then(function(results) {
                    return results;
                });
            };

            var _deleteRefreshTokens = function(tokenid) {

                return $http.delete(serviceBase + 'api/refreshtokens/?tokenid=' + tokenid).then(function(results) {
                    return results;
                });
            };

            tokenManagerServiceFactory.deleteRefreshTokens = _deleteRefreshTokens;
            tokenManagerServiceFactory.getRefreshTokens = _getRefreshTokens;

            return tokenManagerServiceFactory;

        });
})();