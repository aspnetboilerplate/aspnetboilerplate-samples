(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.privateEmail',
        function($scope, privateEmailService) {
            var vm = this;

            vm.sendEmailArgs = {
                userName: 'admin',
                subject: 'test subject' + new Date().getTime(),
                body: 'test body ' + new Date().getTime(),
                sendNotification: true
            }

            vm.sendEmail = function() {
                privateEmailService.send(vm.sendEmailArgs).success(function () {
                    abp.notify.success("Email sent to the server.");

                    //reset mail!
                    vm.sendEmailArgs.subject = 'test subject ' + new Date().getTime();
                    vm.sendEmailArgs.body = 'test body ' + new Date().getTime();
                });
            };
            
            vm.formatNotificationMessage = function (userNotification) {
                return abp.notifications.getFormattedMessageFromUserNotification(userNotification);
            };
        }
    ]);
})();