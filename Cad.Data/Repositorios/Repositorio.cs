using Cad.Data.Contexto;
using Cad.Data.Repositorios.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Cad.Data.Repositorios
{
    public class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        protected CADContext Context;
        protected DbSet<TEntidade> Set;

        public Repositorio()
        {
            Context = new CADContext();
            Set = Context.Set<TEntidade>();
        }

        public Repositorio(CADContext contexto)
        {
            Context = contexto;
            Set = Context.Set<TEntidade>();
        }

        public virtual TEntidade Obter(int id)
        {
            return Set.Find(id);
        }

        public virtual TEntidade Obter(Expression<Func<TEntidade, bool>> criterio)
        {
            return Set.Where(criterio).FirstOrDefault();
        }


        public IQueryable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> criterio,
            Func<TEntidade, object> ordenarPor = null,
            params Expression<Func<TEntidade, object>>[] propriedadesDeNavegacao)
        {
            IQueryable<TEntidade> set = Set;

            IncluirPropriedadesNaQuery(propriedadesDeNavegacao, set);

            var resultado = ordenarPor != null ?
                set.Where(criterio).OrderBy(ordenarPor).AsQueryable() :
                set.Where(criterio).AsQueryable();


            return resultado;
        }

        public IQueryable<TEntidade> Todos()
        {
            return Set;
        }

        public bool Existe(int id)
        {
            return Set.Find(id) == null;
        }

        public bool Existe(Expression<Func<TEntidade, bool>> criterio)
        {
            return Set.Any(criterio);
        }

        public int Contar(Expression<Func<TEntidade, bool>> criterio)
        {
            return Set.Count(criterio);
        }

        private void IncluirPropriedadesNaQuery(Expression<Func<TEntidade, object>>[] propriedadesDeNavegacao, IQueryable<TEntidade> entidade)
        {
            propriedadesDeNavegacao.Aggregate(entidade, (current, propriedade) => current.Include(propriedade));
        }
    }
}
