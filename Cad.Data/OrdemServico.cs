namespace Cad.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class OrdemServico
    {
        [Key]
        public int IdentificadorOrdemServico { get; set; }

        public int IdentificadorPessoa { get; set; }

        public DateTime DataRegistro { get; set; }

        public DateTime? DataFimVigencia { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
