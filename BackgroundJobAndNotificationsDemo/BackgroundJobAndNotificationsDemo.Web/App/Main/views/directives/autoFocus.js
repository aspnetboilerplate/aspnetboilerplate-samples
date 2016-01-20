(function () {
    angular.module('app').directive('autoFocus', function () {
          return {
              restrict: 'A',
              link: function ($scope, element) {
                  element[0].focus();
              }
          };
      });
})();