using CAD.Core.Negocio.Mensagens;
using CAD.Core.Negocio.Servicos;
using CAD.Core.Negocio.Servicos.Interface;
using CAD.Infraestrutura.Interface;
using CAD.Infraestrutura.MVC;
using CAD.Infraestrutura.MVC.ModelBinder;
using CAD.Infraestrutura.MVC.Servicos;
using CAD.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace CAD.Controllers
{
    public class ContaController : Controller
    {
        private readonly IConfigurationReader _configurationReader;
        private readonly IUsuarioServico _usuarioServico;
        private readonly ITempDataServico _tempDataServico;
        private const string MensagemKey = "Mensagem";
        private const string ReturnUrlKey = "ReturnUrl";

        public ContaController()
        {
            _usuarioServico = new UsuarioServico();
            _tempDataServico = new TempDataServico(TempData);
            _configurationReader = new ConfigurationReader();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl = null)
        {
            FormsAuthentication.SignOut();
            ViewBag.Mensagem = _tempDataServico.Buscar(MensagemKey);
            _tempDataServico.Adicionar(ReturnUrlKey, returnUrl);
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View("Login");

            var dto = LoginVM.Converter(model);
            _usuarioServico.Autenticar(dto);

            var returnUrl = _tempDataServico.Buscar<string>(ReturnUrlKey);
            return Redirect(string.IsNullOrEmpty(returnUrl) ? _configurationReader.GetAppSetting(ReturnUrlKey) : returnUrl);
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

            _tempDataServico.Adicionar(MensagemKey, Core.Negocio.Mensagens.Mensagem.M012);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult NovaSenha([ModelBinder(typeof(TokenModelBinder))]int id)
        {
            var podeAtualizarSenha = _usuarioServico.VerificarSeDeveAtualizarSenha(id);

            if (podeAtualizarSenha)
            {
                var novaSenhaModel = new NovaSenhaVM
                {
                    IdentificadorUsuario = id
                };
                return View("NovaSenha", novaSenhaModel);
            }

            _tempDataServico.Adicionar(MensagemKey, Mensagem.M014);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult MudarSenha(NovaSenhaVM model)
        {
            var dto = NovaSenhaVM.Converter(model);
            _usuarioServico.MudarSenha(dto);

            _tempDataServico.Adicionar(MensagemKey, Mensagem.M016);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaVM model)
        {
            if (!ModelState.IsValid) return View();

            var dto = AlterarSenhaVM.Converter(model);
            _usuarioServico.AlterarSenha(dto);

            _tempDataServico.Adicionar(MensagemKey, Mensagem.M002);
            return RedirectToAction("Login");
        }
    }
}