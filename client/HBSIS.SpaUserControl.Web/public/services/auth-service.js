﻿(function() {
    'use strict';
    angular
        .module('spaHbsisApp')
        .factory('authService', authService);

    authService.inject = ['$http, $q, localStorageService, baseConfig'];

    function authService($http, $q, localStorageService, baseConfig) {

        var serviceBase = baseConfig.apiUrl.replace('api/v1/', '');
        var authServiceFactory = {};

        var _authentication = {
            isAuth: false,
            userName: "",
            useRefreshTokens: false
        };

        var _externalAuthData = {
            provider: "",
            userName: "",
            externalAccessToken: ""
        };

        var _saveRegistration = function(registration) {

            _logOut();

            return $http.post(serviceBase + 'account/register', registration).then(function(response) {
                return response;
            });

        };

        var _login = function(loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            if (loginData.useRefreshTokens) {
                data = data + "&client_id=" + baseConfig.clientId;
            }

            var deferred = $q.defer();

            $http.post(serviceBase + 'authtoken', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(function(response) {

                    if (loginData.useRefreshTokens) {
                        localStorageService.set('authorizationData', { token: response.data.access_token, userName: loginData.userName, refreshToken: response.data.refresh_token, useRefreshTokens: true });
                    } else {
                        localStorageService.set('authorizationData', { token: response.data.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
                    }
                    _authentication.isAuth = true;
                    _authentication.userName = loginData.userName;
                    _authentication.useRefreshTokens = loginData.useRefreshTokens;

                    deferred.resolve(response);

                }, function(err, status) {
                    _logOut();
                    deferred.reject(err);
                });

            return deferred.promise;

        };

        var _logOut = function() {

            localStorageService.remove('authorizationData');

            _authentication.isAuth = false;
            _authentication.userName = "";
            _authentication.useRefreshTokens = false;

        };

        var _fillAuthData = function() {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                _authentication.useRefreshTokens = authData.useRefreshTokens;
            }

        };

        var _refreshToken = function() {
            var deferred = $q.defer();

            var authData = localStorageService.get('authorizationData');

            if (authData) {

                if (authData.useRefreshTokens) {

                    var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + baseConfig.clientId;

                    localStorageService.remove('authorizationData');

                    $http.post(serviceBase + 'authtoken', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function(response) {

                        localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: response.refresh_token, useRefreshTokens: true });

                        deferred.resolve(response);

                    }).error(function(err, status) {
                        _logOut();
                        deferred.reject(err);
                    });
                }
            }

            return deferred.promise;
        };

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;
        authServiceFactory.refreshToken = _refreshToken;

        return authServiceFactory;
    }
})();