(function () {
    angular.module('app').controller('app.views.users.createModal', [
        '$scope', '$modalInstance', 'abp.services.app.user',
        function ($scope, $modalInstance, userService) {
            var vm = this;

            vm.user = {
                isActive: true
            };

            vm.save = function () {
                userService.createUser(vm.user)
                    .success(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $modalInstance.close();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();