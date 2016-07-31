(function ($) {
    $(function () {

        var _$taskStateCombobox = $('#TaskStateCombobox');

        _$taskStateCombobox.change(function() {
            location.href = '/Tasks?state=' + _$taskStateCombobox.val();
        });

    });
})(jQuery);