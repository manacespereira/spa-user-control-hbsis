(function() {
    'use strict';

    angular
        .module('spaHbsisApp')
        .factory('clientService', clientService);

    clientService.inject = ['$http, baseConfig'];

    function clientService($http, baseConfig) {
        var clientsApiUrl = baseConfig.apiUrl + 'clients/';

        var service = {
            get: _get,
            getAll: _getAll,
            save: _save,
            delete: _delete
        };

        return service;

        ////////////////
        function _get(id) {
            return $http.get(clientsApiUrl + id);
        }

        function _getAll() {
            return $http.get(clientsApiUrl);
        }

        function _save(client) {
            if (client.id)
                return $http.put(clientsApiUrl, client);
            return $http.post(clientsApiUrl, client);
        }

        function _delete(client) {
            console.log(client);
            return $http.delete(clientsApiUrl + client.id);
        }
    }
})();