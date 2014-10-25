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
                    birthCityName: {
                        title: 'Birth city'
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