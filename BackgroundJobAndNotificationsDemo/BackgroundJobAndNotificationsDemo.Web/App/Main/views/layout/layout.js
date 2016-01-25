(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            $scope.globalNotifications = [];


            abp.event.on('abp.notifications.received', function(notification) {
                $scope.$apply(function () {
                    $scope.globalNotifications.unshift(notification);
                });
            });

        }]);
})();