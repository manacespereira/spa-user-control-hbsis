﻿(function() {
    'use strict';
    angular
        .module('spaHbsisApp')
        .controller('tokensManagerController', tokensManagerController);

    tokensManagerController.inject = ['$scope, tokensManagerService'];

    function tokensManagerController() {

        $scope.refreshTokens = [];

        tokensManagerService.getRefreshTokens().then(function(results) {

            $scope.refreshTokens = results.data;

        }, function(error) {
            alert(error.data.message);
        });

        $scope.deleteRefreshTokens = function(index, tokenid) {

            tokenid = window.encodeURIComponent(tokenid);

            tokensManagerService.deleteRefreshTokens(tokenid).then(function(results) {

                $scope.refreshTokens.splice(index, 1);

            }, function(error) {
                alert(error.data.message);
            });
        }

    }
})();