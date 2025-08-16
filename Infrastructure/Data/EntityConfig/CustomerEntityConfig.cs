using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfig
{
    public class CustomerEntityConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(0)
                .HasColumnName("Id")
                .HasColumnType("uuid")
                .HasComment("Chave para o cliente");
            builder
                .Property(p => p.TypeCustomer)
                .HasColumnOrder(1)
                .HasColumnName("TypeCustomer")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(2)
                .HasComment("Tipo do Usuário [PJ|PF]");
            builder
                .Property(p => p.Name)
                .HasColumnOrder(2)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Nome para identificar o cliente");
            builder
                .Property(p => p.Document)
                .HasColumnOrder(3)
                .HasColumnName("Document")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(18)
                .HasComment("Documento para identificar o cliente 000.000.000-00 | 00.000.000/0000-00");
            builder
                .Property(p => p.Email)
                .HasColumnOrder(4)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasComment("Email para identificar o cliente");
            builder
                .Property(p => p.Phone)
                .HasColumnOrder(5)
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .HasComment("Phone para identificar o cliente (00) 99999-9999 | (00) 9999-9999");
            builder
                .Property(p => p.Address)
                .HasColumnOrder(6)
                .HasColumnName("Address")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasComment("Logradouro para localização o cliente");
            builder
                .Property(p => p.State)
                .HasColumnOrder(7)
                .HasColumnName("Estado")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .HasComment("Estado para localização o cliente");
            builder
                .Property(p => p.City)
                .HasColumnOrder(8)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasComment("Cidade para localização o cliente");
            builder
                .Property(p => p.Neighborhood)
                .HasColumnOrder(9)
                .HasColumnName("Neighborhood")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasComment("Bairro para localização o cliente");
            builder
                .Property(p => p.Complement)
                .HasColumnOrder(10)
                .HasColumnName("Complement")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasComment("Complemento para localização o cliente");
            builder
                .Property(p => p.ZipCode)
                .HasColumnOrder(11)
                .HasColumnName("ZipCode")
                .HasColumnType("varchar")
                .HasMaxLength(9)
                .HasComment("Cep para localização o cliente 29000-000");
            builder
                .Property(p => p.Created)
                .HasColumnOrder(14)
                .HasColumnName("CreatedAt")
                .HasColumnType("timestamptz") // timestamp with time zone
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'")
                .HasComment("Data de criação no fuso horário do Brasil");
            builder
                .HasIndex(p => new
                {
                    p.Document
                })
                .HasDatabaseName("idx_document_unique")
                .IsUnique();

            builder
                .ToTable("Customer", "domain")
                .HasKey(c => c.Id)
                .HasName("pk_customer");
        }
    }
}

