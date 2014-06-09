(function () {
    var controllerId = 'sts.controllers.views.task.new';
    var app = angular.module('app');
    app.controller(controllerId, ['$scope', '$location', function ($scope, $location) {
        var vm = this;

        vm.task = {
            description: '',
            assignedPersonId: null
        };

        var localize = abp.localization.getSource('SimpleTaskSystem');

        vm.people = []; //TODO: Move Person combo to a directive

        abp.services.tasksystem.person.getAllPeople({}).done(function (data) {
            $scope.$apply(function () {
                vm.people = data.people;
            });
        });

        vm.saveTask = function () {
            abp.ui.setBusy($('#NewTaskForm'), {
                promise: abp.services.tasksystem.task.createTask(vm.task)
                    .done(function () {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                        $scope.$apply(function () {
                            $location.path('/'); //TODO: Look for a better way!
                        });                           
                    })
            });
        };

    }]);
})();