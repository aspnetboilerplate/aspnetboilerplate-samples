(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            $scope.globalUserNotifications = [];

            abp.event.on('abp.notifications.received', function (userNotification) {
                console.log(userNotification);
                $scope.$apply(function () {
                    $scope.globalUserNotifications.unshift(userNotification);
                    abp.notify.info(userNotification.notification.data.senderName + " sent an email to your email address!");
                });
            });

        }]);
})();