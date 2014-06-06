(function () {
    var controllerId = 'sts.controllers.views.task.list';
    var app = angular.module('app');

    app.controller(controllerId, ['$scope', function ($scope) {
        var vm = this;

        vm.localize = abp.localization.getSource('SimpleTaskSystem');

        vm.refreshTasks = function () {
            abp.services.tasksystem.task.getTasks({
                state: vm.selectedTaskState > 0 ? vm.selectedTaskState : null
            }).done(function (data) {
                alert(1);
                $scope.$apply(function() {
                    vm.tasks = data.tasks;
                });
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

        vm.refreshTasks();
    }]);
})();