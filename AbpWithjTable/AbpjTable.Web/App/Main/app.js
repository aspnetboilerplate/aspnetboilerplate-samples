(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('people', {
                    url: '/',
                    templateUrl: '/App/Main/views/people/people.cshtml',
                    menu: 'People'
                })
                .state('cities', {
                    url: '/cities',
                    templateUrl: '/App/Main/views/cities/cities.cshtml',
                    menu: 'Cities'
                });
        }
    ]);
})();