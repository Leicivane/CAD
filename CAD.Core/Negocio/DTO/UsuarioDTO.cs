namespace Cad.Core.Negocio.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
            
        }

        public UsuarioDTO(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public string Login { get; set; }
        public string Senha { get; set; }
        public bool LembrarSenha { get; set; }
    }
}