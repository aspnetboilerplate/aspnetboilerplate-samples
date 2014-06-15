(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngRoute',
        'ngSanitize',

        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    app.constant('routes', getRoutes());

    function getRoutes() {
        return [
            {
                url: '/', //default: /task/list
                config: {
                    templateUrl: '/App/Main/views/task/list.cshtml',
                    menuItem: 'TaskList'
                }
            },
            {
                url: '/task/new',
                config: {
                    templateUrl: '/App/Main/views/task/new.cshtml',
                    menuItem: 'NewTask'
                }
            }
        ];
    }

    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });

        $routeProvider.otherwise({ redirectTo: abp.appPath });
    }

    app.run(['$rootScope', '$location', '$routeParams', '$route', function ($rootScope, $location, $routeParams, $route) {
        $rootScope.$on('$routeChangeSuccess', function (event, next, current) {
            if (next && next.$$route) {
                $rootScope.activeMenu = next.$$route.menuItem;
            }
        });
    }]);
})();