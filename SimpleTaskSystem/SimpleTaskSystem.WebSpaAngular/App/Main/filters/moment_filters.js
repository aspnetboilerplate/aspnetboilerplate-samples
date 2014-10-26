angular.module('app')
    .filter('momentFromNow', function() {
        return function(input) {
            return moment(input).fromNow();
        };
    });