using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Enums;
using CAD.Core.Negocio.Mensagens;
using CAD.Core.Util.Guard;
using CAD.Core.Util.Mapeador;
using CAD.Infraestrutura.MVC.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAD.Models
{
    public class NovoFuncionarioVM
    {
        public int FuncionarioId { get; set; }
        public string NomeMunicipio { get; set; }
        [Display(Name = "UF")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public int UFId { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string CEP { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string RG { get; set; }
        [CPF(ErrorMessageResourceName = "M011", ErrorMessageResourceType = typeof(Mensagem))]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string CPF { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        [Display(Name = "Sexo")]
        public TipoSexo? Sexo { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Cidade { get; set; }
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Bairro { get; set; }
        [Display(Name = "Ponto de Referência")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string PontoReferencia { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        public ICollection<TelefoneVM> Telefones { get; set; }
        [Display(Name = "Inativo")]
        public bool IsInativo { get; set; }

        [Display(Name = "Setor")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public TipoSetor? Setor { get; set; }
        [Display(Name = "Função")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public TipoFuncao? Funcao { get; set; }
        public NovoFuncionarioVM()
        {
            DataNascimento = DateTime.Now;
            Telefones = new List<TelefoneVM>();
        }

        public static NovoFuncionarioDTO Converter(NovoFuncionarioVM model)
        {
            Guard.IsNotNull(model, "model");

            var destino = Mapeador.MapearPara<NovoFuncionarioVM, NovoFuncionarioDTO>(model);
            destino.Endereco = new EnderecoDTO();
            destino.Endereco.Bairro = model.Bairro;
            destino.Endereco.CEP = model.CEP;
            destino.Endereco.Logradouro = model.Logradouro;
            destino.Endereco.IdEstado = model.UFId;
            destino.Endereco.IdMunicipio = Convert.ToInt32(model.Cidade);


            foreach (var telefoneVM in model.Telefones)
            {
                destino.Telefones.Add(Mapeador.MapearPara<TelefoneVM, TelefoneDTO>(telefoneVM));
            }
            return destino;
        }

        public static NovoFuncionarioVM Converter(NovoFuncionarioDTO model)
        {
            Guard.IsNotNull(model, "model");

            var destino = Mapeador.MapearPara<NovoFuncionarioDTO, NovoFuncionarioVM>(model);
            destino.UFId = model.Endereco.IdEstado;
            destino.Bairro = model.Endereco.Bairro;
            destino.CEP = model.CEP;
            destino.Logradouro = model.Logradouro;
            destino.Sexo = model.Sexo;
            destino.Setor = model.Setor;
            destino.PontoReferencia = model.PontoReferencia;
            destino.UFId = model.Endereco.IdEstado;

            destino.NomeMunicipio = model.Endereco.NomeMunicipio;
            foreach (var telefoneVM in model.Telefones)
            {
                destino.Telefones.Add(Mapeador.MapearPara<TelefoneDTO, TelefoneVM>(telefoneVM));
            }
            return destino;
        }
    }

    
}