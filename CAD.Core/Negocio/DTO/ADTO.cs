using Cad.Data.Entidades;
using CAD.Core.Negocio.Enums;
using CAD.Core.Util.Guard;
using CAD.Core.Util.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CAD.Core.Negocio.DTO
{
    public class NovoFuncionarioDTO
    {
        public int FuncionarioId { get; set; }
        public string CEP { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public TipoSexo? Sexo { get; set; }
        public TipoSetor Setor { get; set; }
        public TipoFuncao Funcao { get; set; }

        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsInativo { get; set; }

        public EnderecoDTO Endereco { get; set; }
        public ICollection<TelefoneDTO> Telefones { get; set; }

        public NovoFuncionarioDTO()
        {
            Telefones = new List<TelefoneDTO>();
        }

        public static NovoFuncionarioDTO Converter(Pessoa funcionario)
        {
            Guard.IsNotNull(funcionario, "funcionario");

            var destino = Mapeador.MapearPara<Pessoa, NovoFuncionarioDTO>(funcionario);
            destino.Endereco = new EnderecoDTO();
            destino.Endereco.Bairro = funcionario.Enderecos.First().Bairro;
            destino.Endereco.CEP = funcionario.Enderecos.First().CEP;
            destino.Endereco.Logradouro = funcionario.Enderecos.First().CEP;


            foreach (var telefoneVM in funcionario.Telefones)
            {
                destino.Telefones.Add(Mapeador.MapearPara<Telefone, TelefoneDTO>(telefoneVM));
            }
            return destino;
        }
    }

    public class TelefoneDTO
    {
        public TipoTelefone TipoTelefone { get; set; }

        public string DDD { get; set; }
        public string Numero { get; set; }
        public string HorarioDeContato { get; set; }
    }

    public class EnderecoDTO
    {
        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        public string CEP { get; set; }
    }
}
