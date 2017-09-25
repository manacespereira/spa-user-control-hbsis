(function() {
    'use strict';

    angular
        .module('spaHbsisApp')
        .factory('clientService', clientService);

    clientService.inject = ['$http, baseConfig'];

    function clientService($http, baseConfig) {
        var clientsApiUrl = baseConfig.apiUrl + 'clients/';

        var service = {
            getAll: _getAll,
            save: _save
        };

        return service;

        ////////////////
        function _getAll() {
            return $http.get(clientsApiUrl);
        }

        function _save(client) {
            console.log(client);
            return $http.post(clientsApiUrl, client);
        }
    }
})();