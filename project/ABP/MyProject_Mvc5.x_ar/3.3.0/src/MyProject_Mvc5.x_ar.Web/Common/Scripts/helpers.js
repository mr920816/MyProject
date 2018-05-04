var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('x_ar');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);