(function() {
    abp.event.on('abp.notifications.received', function (userNotification) {
        abp.notifications.showUiNotifyForUserNotification(userNotification);
    });
})();