using Cad.Data.Contexto;
using Cad.Data.Entidades;
using Cad.Data.Repositorios;
using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Enums;
using CAD.Core.Util.Extensao;
using CAD.Core.Util.Guard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CAD.Core.Negocio.Servicos
{
    public class FuncionarioServico
    {
        private readonly RepositorioAtualizavel<Pessoa> _repositorioPessoa;
        private readonly RepositorioAtualizavel<Endereco> _repostorioEndereco;
        private readonly RepositorioAtualizavel<DocumentoIdentificacao> _repositorioDocumentoIdentificacao;
        private readonly RepositorioAtualizavel<Usuario> _repostorioUsuario;
        private readonly RepositorioAtualizavel<UsuarioDepartamento> _repositorioUsuarioDepartamento;
        private readonly RepositorioAtualizavel<Telefone> _repositorioTelefone;
        private readonly CADContext _contexto;

        public FuncionarioServico()
        {
            _contexto = new CADContext();
            _repositorioPessoa = new RepositorioAtualizavel<Pessoa>(_contexto);
            _repostorioEndereco = new RepositorioAtualizavel<Endereco>(_contexto);
            _repositorioDocumentoIdentificacao = new RepositorioAtualizavel<DocumentoIdentificacao>(_contexto);
            _repostorioUsuario = new RepositorioAtualizavel<Usuario>(_contexto);
            _repositorioUsuarioDepartamento = new RepositorioAtualizavel<UsuarioDepartamento>(_contexto);
            _repositorioTelefone = new RepositorioAtualizavel<Telefone>(_contexto);


        }
        public void RegistrarFuncionario(NovoFuncionarioDTO dto)
        {
            Guard.IsNotNull(dto);

            var pessoa = new Pessoa
            {
                DataNascimento = dto.DataNascimento,
                CodigoTipoSexo = (int)dto.Sexo.Value,
                NomePessoa = dto.Nome,
                SobrenomePessoa = dto.Sobrenome,
                EmailPessoa = dto.Email,
                DataRegistro = DateTime.Now
            };

            _repositorioPessoa.Adicionar(pessoa);
            var endereco = new Endereco()
            {
                Pessoa = pessoa,
                Logradouro = dto.Endereco.Logradouro,
                Bairro = dto.Endereco.Bairro,
                CEP = dto.Endereco.CEP.Sanitizado(),
                IdentificadorEstado = dto.Endereco.IdEstado,
                IdentificadorMunicipio = dto.Endereco.IdMunicipio,
            };
            _repostorioEndereco.Adicionar(endereco);
            var documentoRG = new DocumentoIdentificacao()
            {
                Pessoa = pessoa,
                CodigoTipoDocumentoIdentificacao = (int)TipoDocumento.RG,
                NumeroDocumentoIdentificacao =
                    dto.RG.Sanitizado()
            };
            _repositorioDocumentoIdentificacao.Adicionar(documentoRG);

            var documentoCPF = new DocumentoIdentificacao()
            {
                Pessoa = pessoa,
                CodigoTipoDocumentoIdentificacao = (int)TipoDocumento.CPF,
                NumeroDocumentoIdentificacao =
                    dto.CPF.Sanitizado()
            };


            _repositorioDocumentoIdentificacao.Adicionar(documentoCPF);

            var usuario = new Usuario()
            {
                Pessoa = pessoa,
                AlteracaoSenha = false,
                CodigoTipoUsuario = (int)TipoUsuario.Funcionario,
                Desativado = dto.IsInativo,
                Senha = "SENHA PADRÃO",
            };

            _repostorioUsuario.Adicionar(usuario);

            var departamento = new UsuarioDepartamento()
            {
                Usuario = usuario,
                IdentificadorUsuarioSetor = (int)dto.Setor,
                IdentificadorUsuarioFuncao = (int)dto.Funcao
            };

            foreach (var telefoneDTO in dto.Telefones)
            {
                var tmp = new Telefone
                {
                    Pessoa = pessoa,
                    PrefixoTelefone = telefoneDTO.DDD.Sanitizado(),
                    NumeroTelefone = telefoneDTO.Numero.Sanitizado(),
                };

                _repositorioTelefone.Adicionar(tmp);
            }

            _repositorioUsuarioDepartamento.Adicionar(departamento);
            _repositorioDocumentoIdentificacao.SalvarAlteracoes();
        }

        public ICollection<FuncionarioResumoDTO> ListarFuncionarios()
        {
            var funcionarios = (from p in _contexto.Pessoas
                               where p.Usuarios.Any()
                               select new
                               {
                                   IdPessoa = p.IdentificadorPessoa,
                                   IdUsuario = p.Usuarios.FirstOrDefault().IdentificadorPessoa,
                                   Nome = p.NomePessoa,
                                   Sobrenome = p.SobrenomePessoa,
                                   CPF =
                                       p.DocumentosIdentificacao.FirstOrDefault(
                                           d => d.CodigoTipoDocumentoIdentificacao == (int)TipoDocumento.CPF).NumeroDocumentoIdentificacao,
                                   Email = p.EmailPessoa,
                                   Telefone = p.Telefones.FirstOrDefault().NumeroTelefone
                               }).ToList();


            return funcionarios.Select(f => new FuncionarioResumoDTO()
            {
                IdPessoa = f.IdPessoa,
                IdUsuario = f.IdUsuario,
                Email = f.Email,
                CPF = f.CPF,
                Sobrenome = f.Sobrenome,
                Nome = f.Nome,
                Telefone = f.Telefone
            }).ToList();
        }

        public NovoFuncionarioDTO ObterFuncionario(int idPessoa)
        {
            var funcionario = _repositorioPessoa.Obter(idPessoa);
            if (funcionario == null) return null;

            return NovoFuncionarioDTO.Converter(funcionario);
        }
    }

    public class FuncionarioResumoDTO
    {
        public int IdUsuario { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}