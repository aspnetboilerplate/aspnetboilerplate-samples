﻿(function () {
    var app = angular.module('app');

    var controllerId = 'sts.views.task.list';
    app.controller(controllerId, [
        '$scope', 'abp.services.tasksystem.task',
        function ($scope, taskService) {
            var vm = this;

            vm.localize = abp.localization.getSource('SimpleTaskSystem');

            vm.tasks = [];

            $scope.selectedTaskState = 0;

            $scope.$watch('selectedTaskState', function (value) {
                vm.refreshTasks();
            });

            vm.refreshTasks = function () {
                abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    taskService.getTasks({ //Call application service method directly from javascript
                        state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
                    }).then(function (data) {
                        vm.tasks = data.data.tasks;
                    })
                );
            };

            vm.changeTaskState = function (task) {
                var newState;
                if (task.state == 1) {
                    newState = 2; //Completed
                } else {
                    newState = 1; //Active
                }

                taskService.updateTask({
                    taskId: task.id,
                    state: newState
                }).then(function () {
                    task.state = newState;
                    abp.notify.info(vm.localize('TaskUpdatedMessage'));
                });
            };

            vm.getTaskCountText = function () {
                return abp.utils.formatString(vm.localize('Xtasks'), vm.tasks.length);
            };
        }
    ]);
})();