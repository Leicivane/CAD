namespace CAD.Core.Negocio.Servicos.Interface
{
    public class UsuarioAlterarSenhaDTO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmacaoSenha { get; set; }

    }
}