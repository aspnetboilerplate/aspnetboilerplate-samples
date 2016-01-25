(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            $scope.globalNotifications = [];

            var commonHub = $.connection.abpCommonHub;

            commonHub.client.getNotification = function (notification) {
                abp.log.info('Got notification: ' + notification);
                $scope.$apply(function() {
                    $scope.globalNotifications.unshift(notification);
                });
            };

            $.connection.hub.start().done(function () {
                abp.log.info('Connected to SignalR server');
            });

        }]);
})();