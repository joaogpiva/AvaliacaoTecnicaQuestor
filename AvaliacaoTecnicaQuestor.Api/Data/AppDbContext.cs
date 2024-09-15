using AvaliacaoTecnicaQuestor.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoTecnicaQuestor.Api.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<Boleto> Boletos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddBancoMapping(modelBuilder);

            AddBoletoMapping(modelBuilder);
        }

        private static void AddBancoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banco>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Banco>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Banco>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Banco>()
                .Property(b => b.Codigo)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Banco>()
                .HasIndex(b => b.Codigo)
                .IsUnique();

            modelBuilder.Entity<Banco>()
                .Property(b => b.PercentualJuros)
                .IsRequired();
        }

        private static void AddBoletoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Boleto>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Boleto>()
                .Property(b => b.NomePagador)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Boleto>()
                .Property(b => b.IdentificacaoPagador)
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Boleto>()
                .Property(b => b.NomeBeneficiario)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Boleto>()
                .Property(b => b.IdentificacaoBeneficiario)
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Boleto>()
                .Property(b => b.Valor)
                .IsRequired();

            modelBuilder.Entity<Boleto>()
                .Property(b => b.DataVencimento)
                .IsRequired();

            modelBuilder.Entity<Boleto>()
                .Property(b => b.Observacao)
                .HasMaxLength(150)
                .IsRequired(false);

            modelBuilder.Entity<Boleto>()
                .HasOne(boleto => boleto.Banco)
                .WithOne()
                .HasForeignKey<Boleto>(boleto => boleto.BancoId);
        }
    }
}
