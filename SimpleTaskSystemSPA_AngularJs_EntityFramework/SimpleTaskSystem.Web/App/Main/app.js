(function () {
    'use strict';

    var localize = abp.localization.getSource('SimpleTaskSystem');

    var app = angular.module('app', [
        'ngAnimate',
        'ngRoute',
        'ngSanitize',

        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    app.constant('routes', [
        {
            url: '/', //default: /task/list
            config: {
                templateUrl: '/App/Main/views/task/list.cshtml',
                menuText: localize('TaskList'),
                menuItem: 'TaskList'
            }
        },
        {
            url: '/about',
            config: {
                templateUrl: '/App/Main/views/task/new.cshtml',
                menuText: localize('NewTask'),
                menuItem: 'NewTask'
            }
        }
    ]);

    app.config([
        '$routeProvider', 'routes',
        function ($routeProvider, routes) {
            routes.forEach(function (route) {
                $routeProvider.when(route.url, route.config);
            });

            $routeProvider.otherwise({
                redirectTo: '/'
            });
        }
    ]);

    app.run([
        '$rootScope',
        function ($rootScope) {
            $rootScope.$on('$routeChangeSuccess', function (event, next, current) {
                if (next && next.$$route) {
                    $rootScope.activeMenu = next.$$route.menuItem; //Used in layout.cshtml to make selected menu 'active'.
                }
            });
        }
    ]);
})();