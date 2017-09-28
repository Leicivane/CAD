using System;
using System.Collections.Generic;
using CAD.Core.Negocio.Mensagens;
using System.ComponentModel.DataAnnotations;
using CAD.Core.Negocio.Enums;

namespace CAD.Models
{
    public class NovoFuncionarioVM
    {
        public string UF;
        public string CEP;

        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }

        public string RG { get; set; }
        public string CPF { get; set; }
        public TipoSexo Sexo { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<TelefoneVM> Telefones { get; set; }

        public NovoFuncionarioVM()
        {
        }

        public static object Converter(NovoFuncionarioVM model, IEnumerable<string> horarioDeContato, IEnumerable<string> numero, IEnumerable<string> ddd)
        {
            throw new NotImplementedException();
        }
    }
}