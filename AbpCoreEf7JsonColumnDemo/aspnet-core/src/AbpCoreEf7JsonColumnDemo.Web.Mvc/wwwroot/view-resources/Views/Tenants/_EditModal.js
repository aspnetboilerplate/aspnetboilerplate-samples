(function ($) {
    var _tenantService = abp.services.app.tenant,
        l = abp.localization.getSource('AbpCoreEf7JsonColumnDemo'),
        _$modal = $('#TenantEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var tenant = _$form.serializeFormToObject();

        // JSON column sample code
        tenant.metadata = {};
        tenant.metadata.LogoId = _$form.find('#Metadata_LogoId').val();
        tenant.metadata.Address = _$form.find('#Metadata_Address').val();
        tenant.metadata.Description = _$form.find('#Metadata_Description').val();
        
        abp.ui.setBusy(_$form);
        _tenantService.update(tenant).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('tenant.edited', tenant);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
