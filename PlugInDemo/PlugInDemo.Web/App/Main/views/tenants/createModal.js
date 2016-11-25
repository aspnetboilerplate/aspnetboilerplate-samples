(function () {
    angular.module('app').controller('app.views.tenants.createModal', [
        '$scope', '$modalInstance', 'abp.services.app.tenant',
        function ($scope, $modalInstance, tenantService) {
            var vm = this;

            vm.tenant = {
                tenancyName: '',
                name: '',
                adminEmailAddress: '',
                connectionString: ''
            };

            vm.save = function () {
                abp.ui.setBusy();
                tenantService.createTenant(vm.tenant)
                    .success(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $modalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();