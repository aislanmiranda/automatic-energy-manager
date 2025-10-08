using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfig
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(0)
                .HasColumnName("Id")
                .HasColumnType("uuid")
                .HasComment("Chave para o usuário");
            builder
                .Property(p => p.Login)
                .HasColumnOrder(1)
                .HasColumnName("Login")
                .HasColumnType("varchar(20)")
                .HasComment("Login para identificar o usuário")
                .IsRequired();
            builder
                .Property(p => p.Password)
                .HasColumnOrder(2)
                .HasColumnName("Password")
                .HasColumnType("varchar(6)")
                .HasComment("Password para altenticar o usuário")
                .IsRequired();
            builder
               .Property(p => p.Description)
               .HasColumnOrder(3)
               .HasColumnName("Description")
               .HasColumnType("varchar(50)")
               .HasComment("Description para identificar o usuário")
               .IsRequired();
            builder
                .Property(p => p.Status)
                .HasColumnOrder(4)
                .HasColumnName("Status")
                .HasColumnType("smallint")
                .HasDefaultValue(2)
                .HasComment("Status 0-Inativo 1-Ativo 2-EmAnalise")
                .IsRequired();
            builder
                .Property(p => p.Created)
                .HasColumnOrder(5)
                .HasColumnName("CreatedAt")
                .HasColumnType("timestamptz") // timestamp with time zone
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'")
                .HasComment("Data de criação no fuso horário do Brasil");

            builder
                .ToTable("User", "security")
                .HasKey(c => c.Id)
                .HasName("pk_user");
        }
    }
}

