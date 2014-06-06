(function () {
    var controllerId = 'sts.controllers.views.task.list';
    var app = angular.module('app');

    app.controller(controllerId, ['$scope', function ($scope) {
        var vm = this;

        vm.localize = abp.localization.getSource('SimpleTaskSystem');

        $scope.selectedTaskState = 0;

        $scope.$watch('selectedTaskState', function (value) {
            vm.refreshTasks();
        });

        vm.refreshTasks = function () {
            abp.services.tasksystem.task.getTasks({
                state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
            }).done(function (data) {
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