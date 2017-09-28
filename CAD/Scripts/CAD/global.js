$(function () {
    Eventos.ConfigurarValidation();
});

Eventos = {
    ConfigurarValidation: function () {
        debugger;
        if ($(".validation-summary-errors ul li").is(":visible")) {
            $(".validation-summary-errors").addClass("alert alert-danger");
        }
        var forms = $("form");

        forms.each(function (indice, form) {

            var validator = $(form).data("validator");

            var oldErrorPlacement = validator.settings.errorPlacement;
            var oldSuccess = validator.settings.success;

            validator.settings.errorPlacement = function (error, el) {
                oldErrorPlacement(error, el);
                if (error.text() !== "") {
                    el.closest(".form-group").addClass("has-error");
                    error.addClass('text-danger');
                } else {
                    el.closest(".form-group").removeClass("has-error");
                    error.removeClass('text-danger');
                }
            };

            validator.settings.sucess = function (label, b) {
                label.parents('.form-group').removeClass('has-error');
                oldSuccess(label);
            };
        });

        $(".field-validation-error").closest(".form-group").addClass("has-error").end().addClass("text-danger");
    },

    MostrarErroModelState: function (retorno) {
        if (typeof retorno == "string") {
            var mensagem = retorno;
            retorno = {
                listaErros: [mensagem],
                chaves: []
            };
        }

        var erros = retorno.listaErros;
        var chaves = retorno.chaves;

        $.each(chaves, function (index, elem) {
            if ($('[name=' + elem + ']').length === 0) {
                chaves[index] = elem + 'Id';
            }
        });

        var divSummary = $('.validation-summary-valid');

        if (divSummary.length == 0) {
            $(".validation-messages").append("<div class='validation-summary-valid'><ul></ul></div>");
            divSummary = $('.validation-summary-valid');
        }
        divSummary.removeClass('validation-summary-valid');
        divSummary.addClass('validation-summary-errors');

        var ul = divSummary.find('ul');
        $.each(erros, function (index, elem) {
            $(ul).append('<li>' + elem + '</li>');
        });

        $.each(chaves, function (index, elem) {
            $('[name=' + elem + ']').closest('.form-group').addClass('has-error');
        });
        $('[type=submit]').prop('disabled', false);

        Eventos.ConfigurarValidation();
    },
};