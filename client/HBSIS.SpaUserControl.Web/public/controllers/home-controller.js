(function() {
    'use strict';

    angular
        .module('spaHbsisApp')
        .controller('homeController', homeController);

    homeController.inject = ['$scope, clientService'];

    function homeController($scope, clientService) {
        $scope.message = '';
        _getClients();

        $scope.saveClient = _saveClient;

        function _getClients() {
            clientService.getAll()
                .then(function(response) {
                        $scope.clientList = response;
                    },
                    function(error) {
                        alert(error);
                    })

            $scope.clients = clientService.getAll();
        }

        function _saveClient(client) {
            clientService.save(client);
        }
    }
})();