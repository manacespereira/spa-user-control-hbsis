(function() {
    'use strict';

    angular.module('spaHbsisApp')
        .constant('baseConfig', {
            //apiUrl: 'https://spahbsis.azurewebsites.net/api/',
            apiUrl: 'http://localhost:62192/api/v1/',
            baseUrl: '/'
        });
})();