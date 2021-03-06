﻿using Cad.Data.Contexto;
using Cad.Data.Repositorios.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;

namespace Cad.Data.Repositorios
{


    public class RepositorioAtualizavel<TEntidade>
        : Repositorio<TEntidade>, IRepositorioAtualizavel<TEntidade> where TEntidade : class
    {
        public RepositorioAtualizavel(CADContext contexto) : base(contexto) { }

        public void AdicionarOuAtualizar(TEntidade entidade)
        {
            Set.AddOrUpdate(entidade);
        }

        public void Adicionar(TEntidade entidade)
        {
            Set.Add(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            Context.Entry(entidade).State = EntityState.Modified;
        }

        public void Excluir(TEntidade entidade)
        {
            Set.Remove(entidade);
        }

        public void Excluir(int id)
        {
            var entidade = Obter(id);

            Set.Remove(entidade);
        }

        public void SalvarAlteracoes()
        {

            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = ex as DbEntityValidationException;
                if (exception != null)
                {
                    var e = exception.EntityValidationErrors;
                }
                throw;
            }
        }
    }
}
