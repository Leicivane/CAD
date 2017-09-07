using CAD.Infraestrutura.Interface;
using CAD.Models;
using System.Web.Mvc;
using CAD.Core.Negocio.Servicos.Interface;

namespace CAD.Controllers
{
    public class ContaController : Controller
    {
        private readonly IConfigurationReader _configurationReader;
        private readonly IUsuarioServico _usuarioServico;
        private readonly ITempDataServico _tempDataServico;
        private const string Mensagem = "Mensagem";
        private const string ReturnUrl = "ReturnUrl";

        public ContaController(IConfigurationReader configurationReader, IUsuarioServico usuarioServico, ITempDataServico tempDataServico)
        {
            _configurationReader = configurationReader;
            _usuarioServico = usuarioServico;
            _tempDataServico = tempDataServico;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl = null)
        {
            ViewBag.Mensagem = _tempDataServico.Buscar(Mensagem);
            _tempDataServico.Adicionar(ReturnUrl, returnUrl);
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View("Login");

            var dto = LoginVM.Converter(model);
            _usuarioServico.Autenticar(dto);

            var returnUrl = _tempDataServico.Buscar<string>(ReturnUrl);
            return Redirect(string.IsNullOrEmpty(returnUrl) ? _configurationReader.GetAppSetting(ReturnUrl) : returnUrl);
        }

        [HttpGet, Authorize]
        public ActionResult AreaAutorizada()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EsqueciSenha(EsqueciSenhaVM model)
        {
            if (!ModelState.IsValid) return View();

            var dto = EsqueciSenhaVM.Converter(model);

            _usuarioServico.SolicitarMudancaSenha(dto);

            _tempDataServico.Adicionar(Mensagem, Core.Negocio.Mensagens.Mensagem.M012);
            return RedirectToAction("Login");
        }
    }
}