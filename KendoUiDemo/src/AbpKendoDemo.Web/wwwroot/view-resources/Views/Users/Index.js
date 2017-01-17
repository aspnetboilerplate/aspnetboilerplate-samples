(function () {
    $(function () {

        var _userService = abp.services.app.user;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _userService.createUser(user).done(function () {
                _$modal.modal('hide');
                getUsers();
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        $('#UsersGrid').kendoGrid({
            editable: true,
            columns: [{
                field: 'userName',
                title: app.l('UserName')
            }, {
                field: 'name',
                title: app.l('Name')
            }, {
                field: 'surname',
                title: app.l('Surname')
            }, {
                field: 'emailAddress',
                title: app.l('EmailAddress')
            }, {
                field: 'isActive',
                title: app.l('IsActive'),
                template: '#= isActive ? "YES" : "NO" #'
            }],
            dataSource: new kendo.data.DataSource({
                autoSync: true,
                transport: {
                    read: function(options) {
                        abp.services.app.user.getUsers()
                            .done(function (result) {
                                options.success(result.items);
                            })
                            .fail(function(error) {
                                options.error(error);
                            });
                    },
                    update: function(options) {
                        abp.services.app.user.updateUser(options.data)
                            .done(function(result) {
                                options.success(null);
                            })
                            .fail(function(error) {
                                options.error(error);
                            });
                    }
                },
                schema: {
                    model: {
                        id: 'id',
                        fields: {
                            id: {
                                editable: false,
                                nullable: true
                            },
                            userName: {
                                editable: true
                            },
                            name: {
                                editable: true
                            },
                            surname: {
                                editable: true
                            },
                            emailAddress: {
                                editable: true
                            },
                            isActive: {
                                editable: false
                            }
                        }
                    }
                }
            })
        });
    });
})();