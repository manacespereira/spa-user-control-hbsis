describe('homeControllerTests', function() {

    var controller, scope;

    beforeEach(module('spaHbsisApp'));
    beforeEach(inject(function($controller, $rootScope) {
        scope = $rootScope.$new();
        controller = $controller('homeController', { $scope: scope });
    }));

    it('should initialize controller', function() {
        expect(controller).toBeDefined();
    });

    it('sould initialize callsService', inject(function(clientService) {
        expect(clientService).toBeDefined();
    }));

});