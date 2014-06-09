(function () {

    var languages = [
            {
                name: 'tr',
                displayName: 'Türkçe',
                iconClass: 'famfamfam-flag-tr'
            },
            {
                name: 'en',
                displayName: 'English',
                iconClass: 'famfamfam-flag-england'
            }
    ];


    var controllerId = 'sts.controllers.views.layout';

    var app = angular.module('app');




    app.controller(controllerId, ['$scope', function ($scope) {
        var that = this;


        that.getLanguageFlagClass = function () {
            var lang = abp.localization.currentCulture.name;
            for (var i = 0; i < languages.length; i++) {
                if (lang.indexOf(languages[i].name) == 0) {
                    return languages[i].iconClass;
                }
            }

            return '';
        };

        that.getLanguageName = function () {
            var lang = abp.localization.currentCulture.name;
            for (var i = 0; i < languages.length; i++) {
                if (lang.indexOf(languages[i].name) == 0) {
                    return languages[i].displayName;
                }
            }

            return '';
        };

        that.isCurrentLanguage = function(lang) {
            return abp.localization.isCurrentCulture(lang);
        };

    }]);
})();