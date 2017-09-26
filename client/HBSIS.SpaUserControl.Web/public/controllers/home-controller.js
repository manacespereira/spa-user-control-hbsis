(function() {
    'use strict';

    angular
        .module('spaHbsisApp')
        .controller('homeController', homeController);

    homeController.inject = ['$scope, $location, $routeParams, clientService'];

    function homeController($scope, $location, $routeParams, clientService) {
        $scope.message = '';
        var updateMode = $routeParams && $routeParams.id;
        if (updateMode)
            _getClient($routeParams.id);
        else
            _getClients();

        $scope.saveClient = _saveClient;
        $scope.deleteClient = _deleteClient;
        $scope.clearMessage = _clearMessage;
        $scope.getClient = _getClient;
        $scope.getClients = _getClients;


        function _clearMessage() {
            $scope.message = '';
        }

        function _getClient(id) {
            clientService.get(id)
                .then(function(response) {
                        $scope.client = response.data;
                    },
                    function(error) {
                        console.log(error);
                    });
        }

        function _getClients() {
            clientService.getAll()
                .then(function(response) {
                        console.log(response);
                        $scope.clientList = response.data;
                    },
                    function(error) {
                        console.log(error);
                    });
        }

        function _saveClient(client) {
            clientService.save(client).then(
                function(response) {
                    $scope.savedSuccessfully = true;
                    $scope.message = "Cliente salvo com sucesso!";
                    if (!updateMode) {
                        $scope.client = {};
                        $scope.clientForm.$setPristine();
                    }
                },
                function(response) {
                    $scope.savedSuccessfully = false;
                    $scope.message = "Ops! Não conseguimos salvar este cliente! Verifique as informações e tente novamente.";
                }
            );
        }

        function _deleteClient(client) {
            clientService.delete(client)
                .then(function(response) {
                        $scope.savedSuccessfully = true;
                        $scope.message = "Cliente deletado com sucesso!";
                        _getClients();
                    },
                    function() {
                        $scope.savedSuccessfully = false;
                        $scope.message = "Ops! Não conseguimos deletar o cliente.";
                    })
        }
    }
})();