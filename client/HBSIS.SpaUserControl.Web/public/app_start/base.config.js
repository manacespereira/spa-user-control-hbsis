(function() {
    'use strict';

    angular.module('spaHbsisApp')
        .constant('baseConfig', {
            apiUrl: 'http://localhost:62192/api/v1/',
            baseUrl: '/'
        });
})();