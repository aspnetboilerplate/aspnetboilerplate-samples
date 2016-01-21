(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.privateEmail',
        function($scope, privateEmailService) {
            var vm = this;

            vm.sendEmailArgs = {
                userName: 'admin',
                subject: 'test subject',
                body: 'test body ' + new Date().getTime()
            }

            vm.sendEmail = function() {
                privateEmailService.send(vm.sendEmailArgs).success(function () {
                    abp.notify.success('Successfully sent email to ' + vm.sendEmailArgs.userName);
                    vm.sendEmailArgs.body = 'test body ' + new Date().getTime(); //reset mail body!
                });
            };
        }
    ]);
})();