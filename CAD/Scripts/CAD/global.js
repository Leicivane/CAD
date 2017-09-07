$(function () {
    Eventos.ConfigurarValidation();
});

Eventos = {
    ConfigurarValidation: function() {

        $(".validation-summary-errors").addClass("alert alert-danger");
        var forms = $("form");

        forms.each(function(indice, form) {

            var validator = $(form).data("validator");

            var oldErrorPlacement = validator.settings.errorPlacement;
            var oldSuccess = validator.settings.success;

            validator.settings.errorPlacement = function(error, el) {
                oldErrorPlacement(error, el);
                if (error.text() !== "") {
                    el.closest(".form-group").addClass("has-error");
                    error.addClass('text-danger');
                } else {
                    el.closest(".form-group").removeClass("has-error");
                    error.removeClass('text-danger');
                }
            };

            validator.settings.sucess = function(label, b) {
                label.parents('.form-group').removeClass('has-error');
                oldSuccess(label);
            };
        });
    }
};