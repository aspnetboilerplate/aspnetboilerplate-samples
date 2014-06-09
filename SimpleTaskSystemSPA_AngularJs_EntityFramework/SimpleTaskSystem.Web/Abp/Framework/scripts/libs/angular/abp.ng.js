(function () {

    var abpModule = angular.module('abp', []);

    abpModule.filter('localize', function () {
        return function (input, localizationSource) {
            return abp.localization.localize(input, localizationSource);
        };
    });

})();