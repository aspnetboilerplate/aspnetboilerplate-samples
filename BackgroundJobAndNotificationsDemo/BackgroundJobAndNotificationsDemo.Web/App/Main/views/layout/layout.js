(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            $scope.globalUserNotifications = [];

            abp.event.on('abp.notifications.received', function (userNotification) {
                abp.log.debug(userNotification);
                $scope.$apply(function () {
                    $scope.globalUserNotifications.unshift(userNotification);
                    abp.notifications.showUiNotifyForUserNotification(userNotification);
                });
            });

        }]);
})();