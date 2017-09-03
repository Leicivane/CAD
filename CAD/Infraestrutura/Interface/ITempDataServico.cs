namespace CAD.Web.Infraestrutura.Interface
{
    public interface ITempDataServico
    {
        void Adicionar(string key, object valor);
        void Excluir(string key);
        object Buscar(string key);
        T Buscar<T>(string key);
    }
}