// configuração do banco de dados


using Desafio.Marin.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Marin.Infra.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Tipo)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(p => p.Data)
                .IsRequired()
                .HasColumnType("datetimeoffset");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18, 7)");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Cartao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Representante)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.NomeLoja)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
