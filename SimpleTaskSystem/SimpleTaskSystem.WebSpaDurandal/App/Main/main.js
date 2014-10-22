//Shortcuts
requirejs.config({
    paths: {
        'text': '../../Scripts/text',
        'durandal': '../../Scripts/durandal',
        'plugins': '../../Scripts/durandal/plugins',
        'transitions': '../../Scripts/durandal/transitions',
        'abp': '../../Abp',
        'services': '/api/serviceproxies',
        'service': '/Abp/Framework/scripts/libs/requirejs/plugins/service'
    }
});

define('jquery', function () { return jQuery; });
define('knockout', function () { return ko; });

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'durandal/viewEngine', 'durandal/activator', 'knockout'],
    function (system, app, viewLocator, viewEngine, activator, ko) {
        //system.debug(true); //Enable this line only in debug!

        ko.punches.enableAll();

        //This is needed to use cshtml files as view
        viewEngine.convertViewIdToRequirePath = function (viewId) {
            return this.viewPlugin + '!/AbpAppView/Load?viewUrl=/App/Main/' + viewId + '.cshtml';
        };

        //This is needed to return deffered as return values in methods like canActivate.
        activator.defaults.interpretResponse = function (value) {
            if (system.isObject(value)) {
                value = value.can == undefined ? true : value.can;
            }

            if (system.isString(value)) {
                return ko.utils.arrayIndexOf(this.affirmations, value.toLowerCase()) !== -1;
            }

            return value == undefined ? true : value;
        };

        app.title = 'SimpleTaskSystem';

        app.configurePlugins({
            router: true,
            dialog: true,
            widget: true,
            observable: true
        });

        app.start().then(function () {
            viewLocator.useConvention();
            app.setRoot('viewmodels/layout', 'entrance');
        });
    });