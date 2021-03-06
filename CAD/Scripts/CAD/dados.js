﻿var CAD = function () {

};

CAD.prototype.Get = function(options) {
    var opcoes = $.extend(options, {
        method: "GET"
    });

    this.Ajax(opcoes);
}

CAD.prototype.Post = function (options) {

    var opcoes = $.extend(options, {
        method: "POST"
    });
    this.Ajax(opcoes);
}

CAD.prototype.Ajax = function (options) {

    var defaultOptions = {
        header: { 'X-Requested-With': 'XMLHttpRequest' },
        cache: false,
        contentType: "application/json",
        dataType: "json",
        error: function () {
            var retorno = {
                listaErros: ["Ocorreu um erro não esperado"],
                chaves: []
            };
            Eventos.MostrarErroModelState(retorno);
        }
    }

    options = $.extend(defaultOptions, options);
    options.data = JSON.stringify(options.data);

    $.ajax(options);
}


var AjaxCAD = new CAD();