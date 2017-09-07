using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("ORDEM_SERVICO_TB")]
    public partial class OrdemServico
    {
        [Key, Column("ID_ORDEM_SERVICO")]
        public int IdentificadorOrdemServico { get; set; }

        [Column("ID_PESSOA")]
        public int IdentificadorPessoa { get; set; }

        [Column("DATA_REGISTRO")]
        public DateTime DataRegistro { get; set; }

        [Column("DATA_FIM_VIGENCIA")]
        public DateTime? DataFimVigencia { get; set; }

        [StringLength(255), Column("DESCRICAO_ORDEM_SERVICO")]
        public string DescricaoOrdemServico { get; set; }

        [Column("VALOR")]
        public decimal Valor { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
