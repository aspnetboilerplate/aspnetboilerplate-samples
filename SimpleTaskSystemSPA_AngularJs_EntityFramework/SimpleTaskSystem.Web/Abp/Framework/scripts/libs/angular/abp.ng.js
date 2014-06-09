var abp = abp || {};
(function (angular) {

    if (!angular) {
        return;
    }

    // 'abp' module ///////////////////////////////////////////////////////////

    var abpModule = angular.module('abp', []);

    abpModule.factory('services.tasksystem.task', ['$http', function ($http) {
        return new function() {
            this.getTasks = abp.services.tasksystem.task.getTasks;

            //Working on this code!
            //this.getTasks = function(input) {
            //    return $http({
            //        url: '/api/services/tasksystem/task/GetTasks',
            //        method: 'POST',
            //        data: JSON.stringify(input)
            //    });
            //};
        };
    }]);

})(angular || undefined);