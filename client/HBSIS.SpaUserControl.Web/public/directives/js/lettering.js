(function() {
    'use strict';

    angular
        .module('spaHbsisApp')
        .directive('lettering', lettering);

    lettering.inject = ['$filter'];

    function lettering($filter) {
        var directive = {
            restrict: 'E',
            link: link,
            scope: {
                price: '='
            }
        };
        return directive;

        function link(scope, element, attrs) {
            var filter = $filter('priceCallFormatter');
            var priceFormatted = filter(scope.price);

            if (priceFormatted == 'Nada!' || priceFormatted == '-')
                return element[0].innerHTML = '<span class="big-letters-price">' + priceFormatted + '</span>';

            var priceFormattedArray = priceFormatted.split(' ');
            var symbol = priceFormattedArray[0];
            var restOfPrice = priceFormattedArray[1].split(',');

            element[0].innerHTML =
                '<span class="small-letters-price">' + symbol + '</span>' +
                '<span class="big-letters-price">' + restOfPrice[0] + '</span>' +
                '<span class="small-letters-price">, ' + restOfPrice[1] + '</span>';
        }
    };
})();