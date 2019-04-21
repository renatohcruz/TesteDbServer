using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.Modelos;
using Teste.Shared;

namespace Teste.Infra.Contexto
{
    public partial class DbTesteContext : DbContext
    {
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbContaCorrente> TbContaCorrente { get; set; }
        public virtual DbSet<TbLancamento> TbLancamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.Cpf);

                entity.ToTable("TB_Cliente");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbContaCorrente>(entity =>
            {
                entity.HasKey(e => e.Numero);

                entity.ToTable("TB_ContaCorrente");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .ValueGeneratedNever();

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TbLancamento>(entity =>
            {
                entity.ToTable("TB_Lancamento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumeroConta).HasColumnName("numeroConta");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.NumeroContaNavigation)
                    .WithMany(p => p.TbLancamento)
                    .HasForeignKey(d => d.NumeroConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_Lancamento_TB_ContaCorrente");
            });
        }
    }
}
