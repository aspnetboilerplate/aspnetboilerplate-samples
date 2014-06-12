(function () {
    var controllerId = 'sts.controllers.views.task.list';
    var app = angular.module('app');

    app.controller(controllerId, ['$scope', 'services.tasksystem.task', function ($scope, taskService) {
        var vm = this;

        vm.tasks = [];

        vm.localize = abp.localization.getSource('SimpleTaskSystem');

        $scope.selectedTaskState = 0;

        $scope.$watch('selectedTaskState', function (value) {
            vm.refreshTasks();
        });

        vm.refreshTasks = function () {
            taskService.getTasks({
                state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
            }).success(function (data) {
                console.log(arguments);
                vm.tasks = data.tasks;
            }).error(function (a) {
                console.log('error!');
                console.log(arguments);
            });
        };

        vm.changeTaskState = function (task) {
            var newState;
            if (task.state == 1) {
                newState = 2;
            } else {
                newState = 1;
            }

            abp.services.tasksystem.task.updateTask({
                taskId: task.id,
                state: newState
            }).done(function () {
                $scope.$apply(function () {
                    task.state = newState;
                });

                abp.notify.info(vm.localize('TaskUpdatedMessage'));
            });
        };

        vm.getTaskCountText = function () {
            return abp.utils.formatString(vm.localize('Xtasks'), vm.tasks.length);
        };
    }]);
})();