(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.test',
        function ($scope, testService) {
            var vm = this;

            vm.items = [];
            vm.name = '';

            function loadPeopleAndCourses() {
                testService.getPeopleAndCourses().success(function (result) {
                    vm.items = result;
                });
            }

            vm.createPerson = function () {
                testService.createPerson(vm.name).success(function() {
                    loadPeopleAndCourses();
                });
            }

            loadPeopleAndCourses();
        }
    ]);
})();