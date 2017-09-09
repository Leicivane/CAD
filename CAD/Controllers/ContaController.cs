using CAD.Core.Negocio.Servicos;
using CAD.Core.Negocio.Servicos.Interface;
using CAD.Infraestrutura.Interface;
using CAD.Infraestrutura.MVC;
using CAD.Infraestrutura.MVC.ModelBinder;
using CAD.Infraestrutura.MVC.Servicos;
using CAD.Models;
using System.Web.Mvc;

namespace CAD.Controllers
{
    public class ContaController : Controller
    {
        private readonly IConfigurationReader _configurationReader;
        private readonly IUsuarioServico _usuarioServico;
        private readonly ITempDataServico _tempDataServico;
        private const string Mensagem = "Mensagem";
        private const string ReturnUrl = "ReturnUrl";

        public ContaController()
        {
            _usuarioServico = new UsuarioServico();
            _tempDataServico = new TempDataServico(TempData);
            _configurationReader = new ConfigurationReader();
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

        [HttpGet]
        public ActionResult NovaSenha([ModelBinder(typeof(TokenModelBinder))]int id)
        {
            var podeAtualizarSenha = _usuarioServico.VerificarSeDeveAtualizarSenha(id);

            if (podeAtualizarSenha) return View();

            _tempDataServico.Adicionar(Mensagem, "Você não pediu alteração de senha ou sua senha já foi atualizada. Clique abaixo para entrar");
            return RedirectToAction("Login");
        }
    }
}