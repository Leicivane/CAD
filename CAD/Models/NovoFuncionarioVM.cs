using CAD.Core.Negocio.Enums;
using CAD.Core.Negocio.Mensagens;
using CAD.Infraestrutura.MVC.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAD.Models
{
    public class NovoFuncionarioVM
    {
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
        [Display(Name = "Está Inativo")]
        public bool IsInativo { get; set; }

        public NovoFuncionarioVM()
        {
            Telefones = new List<TelefoneVM>();
        }

        public static object Converter(NovoFuncionarioVM model)
        {
            throw new NotImplementedException();
        }
    }
}