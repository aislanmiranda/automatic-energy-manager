using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfig
{
    public class MonitoringEntityConfig : IEntityTypeConfiguration<Monitoring>
    {
        public void Configure(EntityTypeBuilder<Monitoring> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(0)
                .HasColumnName("Id")
                .HasColumnType("uuid")
                .HasComment("Id Monitoring");
            builder
                .Property(p => p.Action)
                .HasColumnOrder(1)
                .HasColumnName("Action")
                .HasColumnType("varchar(3)")
                .HasComment("Para identificar a ação do equipamento [ON | OFF]")
                .IsRequired();
            builder
                .Property(p => p.DateAction)
                .HasColumnOrder(5)
                .HasColumnName("DateAction")
                .HasColumnType("timestamptz") // timestamp with time zone
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'")
                .HasComment("Data de criação no fuso horário do Brasil");

            builder
                 .HasOne(p => p.Customer)
                 .WithMany(p => p.Monitorings)
                 .HasForeignKey(p => p.CustomerId)
                 .HasConstraintName("fk_customer")
                 .IsRequired();
            builder
                 .HasOne(p => p.Equipament)
                 .WithMany(p => p.Monitorings)
                 .HasForeignKey(p => p.EquipamentId)
                 .HasConstraintName("fk_equipament")
                 .IsRequired();
            builder
                .HasIndex(p => new { p.CustomerId, p.EquipamentId })
                .HasDatabaseName("idx_customer_equipament");

            builder
                .ToTable("Monitoring", "domain")
                .HasKey(c => c.Id)
                .HasName("pk_monitoring");
        }
    }
}

