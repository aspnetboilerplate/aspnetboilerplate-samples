var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('PlugInDemo');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);