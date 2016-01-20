var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('BackgroundJobAndNotificationsDemo');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);