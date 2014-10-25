(function () {
    var controllerId = 'app.views.people';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            $('#PeopleTable').jtable({
                title: 'All people',
                paging: true,
                actions: {
                    listAction: {
                        method: abp.services.app.person.getPeople
                    },
                    createAction: {
                        method: abp.services.app.person.createPerson,
                        recordField: 'person'
                    }
                },
                fields: {
                    id: {
                        key: true,
                        list: false
                    },
                    name: {
                        title: 'Name'
                    },
                    surname: {
                        title: 'Name'
                    },
                    birthCityId: {
                        title: 'Birth city',
                        options: function () {
                            var options = [];
                            abp.services.app.city.getAllCities({
                                async: false
                            }).done(function (data) {
                                for (var i = 0; i < data.items.length; i++) {
                                    options.push({
                                        Value: data.items[i].value,
                                        DisplayText: data.items[i].displayText,
                                    });
                                };
                            });
                            return options;
                        }
                    },
                    birthDate: {
                        title: 'Birth day',
                        type: 'date',
                        displayFormat: 'dd.mm.yy'
                    }
                }
            });

            $('#PeopleTable').jtable('load');
        }
    ]);
})();