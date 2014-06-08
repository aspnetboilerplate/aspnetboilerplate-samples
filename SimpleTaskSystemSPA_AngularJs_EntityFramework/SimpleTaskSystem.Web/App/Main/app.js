(function () {
    'use strict';

    var getViewUrl = function (path) {
        return '/AbpAppView/Load?viewUrl=/App/Main/views/' + path + '.cshtml';
    };

    var app = angular.module('app', [
        'ngAnimate',
        'ngRoute',
        'ngSanitize',

        'ui.bootstrap',
        'ui.jq'
    ]);

    app.constant('routes', getRoutes());

    function getRoutes() {
        return [
            {
                url: '/', //default: /task/new
                config: {
                    templateUrl: getViewUrl('task/list'),
                    menuItem: 'TaskList'
                }
            },
            {
                url: '/task/new',
                config: {
                    templateUrl: getViewUrl('task/new'),
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

        $routeProvider.otherwise({ redirectTo: '/' });
    }

    app.run(['$rootScope', '$location', '$routeParams', '$route', function ($rootScope, $location, $routeParams, $route) {
        $rootScope.$on('$routeChangeSuccess', function (event, next, current) {
            if (next && next.$$route) {
                $rootScope.activeMenu = next.$$route.menuItem;
            }
        });
    }]);
})();