define(['plugins/router'],
    function (router) {

        return new function () {
            var that = this;

            that.router = router;

            that.languages = abp.localization.languages;
            that.currentLanguage = abp.localization.currentLanguage;

            that.menu = abp.nav.menus.MainMenu;

            that.activate = function () {
                router.map([
                    { route: '', title: abp.localization.localize('TaskList', 'SimpleTaskSystem'), moduleId: 'viewmodels/tasklist', nav: true, menuName: 'TaskList' },
                    { route: 'new', title: abp.localization.localize('NewTask', 'SimpleTaskSystem'), moduleId: 'viewmodels/newtask', nav: true, menuName: 'NewTask' }
                ]).buildNavigationModel();

                return that.router.activate();
            };
        };
    });