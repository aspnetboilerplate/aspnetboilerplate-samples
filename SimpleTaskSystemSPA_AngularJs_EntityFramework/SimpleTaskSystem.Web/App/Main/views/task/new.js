(function () {
    var controllerId = 'sts.controllers.views.task.list';
    var app = angular.module('app');
    app.controller(controllerId, ['$scope', function ($scope) {
        var vm = this;

        vm.task = {
            description: '',
            assignedPersonId: null
        };

        vm.people = []; //TODO: Move Person combo to a directive

        abp.services.tasksystem.person.getAllPeople().done(function (data) {
            vm.people = data.people;
        });

        that.saveTask = function () {
            if (!_$form.valid()) { //TODO: Make validation with angular's validation system.
                return;
            }

            abp.ui.setBusy(_$view, {
                promise: taskService.createTask(ko.mapping.toJS(that.task))
                    .done(function () {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), that.task.description()));
                        history.navigate('');
                    })
            });
        };

    }]);
})();