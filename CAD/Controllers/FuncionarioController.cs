using CAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using CAD.Core.Negocio.Mensagens;
using CAD.Core.Negocio.Servicos;
using CAD.Infraestrutura.MVC.Servicos;
using Newtonsoft.Json;

namespace CAD.Controllers
{
    public class FuncionarioController : BaseController
    {
        private readonly FuncionarioServico _funcionarioServico;
        private readonly TempDataServico _tempDataServico;

        public FuncionarioController()
        {
            _funcionarioServico = new FuncionarioServico();
            _tempDataServico = new TempDataServico(TempData);


        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Novo()
        {
            ViewBag.Mensagem = _tempDataServico.Buscar(MensagemKey);

            return View("Editor");
        }

        [HttpPost]
        public ActionResult Novo(NovoFuncionarioVM model, IEnumerable<DateTime> horarioDeContato, IEnumerable<string> numero, IEnumerable<string> ddd, IEnumerable<TipoTelefone> tipoTelefone)
        {
            GerarModelTelefone(model, horarioDeContato, numero, ddd, tipoTelefone);
            if (!ModelState.IsValid)
            {
                return View("Editor", model);
            }

            var dto = NovoFuncionarioVM.Converter(model);
            _funcionarioServico.RegistrarFuncionario(dto);


            _tempDataServico.Adicionar(MensagemKey, Mensagem.MN005);
            return RedirectToAction("Novo");
        }

        private void GerarModelTelefone(NovoFuncionarioVM model, IEnumerable<DateTime> horarioDeContato, IEnumerable<string> numero, IEnumerable<string> ddd, IEnumerable<TipoTelefone> tipoTelefone)
        {
            for (int i = 0; i < horarioDeContato.Count(); i++)
            {
                model.Telefones.Add(new TelefoneVM
                {
                    TipoTelefone = tipoTelefone.ToList()[i],
                    DDD = ddd.ToList()[i],
                    HorarioDeContato = horarioDeContato.ToList()[i],
                    Numero = numero.ToList()[i]
                });
            }
        }

        [HttpPost]
        public ActionResult TelefoneJson()
        {
            var view = RenderRazorViewToString("_Telefones", new[] { new TelefoneVM() });
            return SucessJson(view);
        }
    }
}