namespace Cad.Data.Repositorios.Interfaces
{
    public interface IRepositorioAtualizavel<TEntidade> : IRepositorio<TEntidade>
       where TEntidade : class
    {
        void Adicionar(TEntidade entidade);
        void AdicionarOuAtualizar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Excluir(TEntidade entidade);
        void Excluir(int entidade);
        void SalvarAlteracoes();
    }
}
