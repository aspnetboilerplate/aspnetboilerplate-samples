(function ($) {

    $(function () {

        var _testService = abp.services.app.test;

        $('#btnSavePerson').click(function () {
            var personName = $('input[name="person-name"]').val();
            if (!personName) {
                return;
            }

            _testService.createPerson(personName).then(function () {
                window.location.reload();
            });
        });

        $('#btnSaveCourse').click(function () {
            var courseName = $('input[name="course-name"]').val();
            if (!courseName) {
                return;
            }

            _testService.createCourse(courseName).then(function () {
                window.location.reload();
            });
        });
    });

})(jQuery);