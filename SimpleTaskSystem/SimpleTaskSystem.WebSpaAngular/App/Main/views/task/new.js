(function() {
    var app = angular.module('app');

    var controllerId = 'sts.views.task.new';
    app.controller(controllerId, [
        '$scope', '$location', 'abp.services.tasksystem.task', 'abp.services.tasksystem.person',
        function($scope, $location, taskService, personService) {
            var vm = this;

            vm.task = {
                description: '',
                assignedPersonId: null
            };

            var localize = abp.localization.getSource('SimpleTaskSystem');

            vm.people = []; //TODO: Move Person combo to a directive?

            personService.getAllPeople().success(function(data) {
                vm.people = data.people;
            });

            vm.saveTask = function() {
                abp.ui.setBusy(
                    null,
                    taskService.createTask(
                        vm.task
                    ).success(function() {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                        $location.path('/');
                    })
                );
            };
        }
    ]);
})();