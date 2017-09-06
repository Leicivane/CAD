namespace Cad.Data
{
    using System.Data.Entity;

    public partial class CAD : DbContext
    {
        public CAD()
            : base("name=CAD")
        {
        }

        public virtual DbSet<DocumentoIdentificacao> DocumentosIdentificacao { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<OrdemServico> OrdemsServico { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<UsuarioSetor> UsuariosSetor { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<OrdemServico>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<OrdemServico>()
                .Property(e => e.Valor)
                .HasPrecision(15, 0);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.NomePessoa)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.SobreNomePessoa)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.EmailPessoa)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.DocumentosIdentificacao)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Enderecos)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.OrdemsServico)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Telefone>()
                .Property(e => e.PrefixoTelefone)
                .IsUnicode(false);

            modelBuilder.Entity<Telefone>()
                .Property(e => e.NumeroTelefone)
                .IsUnicode(false);

            modelBuilder.Entity<Telefone>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.DescricaoDesativacao)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
