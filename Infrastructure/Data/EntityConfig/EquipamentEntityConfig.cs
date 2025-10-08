﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfig
{
    public class EquipamentEntityConfig : IEntityTypeConfiguration<Equipament>
    {
        public void Configure(EntityTypeBuilder<Equipament> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(0)
                .HasColumnName("Id")
                .HasColumnType("uuid")
                .HasComment("Id do equipamento");
            builder
                .Property(p => p.Tag)
                .HasColumnOrder(1)
                .HasColumnName("Tag")
                .HasColumnType("varchar(20)")
                .HasComment("Tag para identificar do equipamento")
                .IsRequired();
            builder
                .Property(p => p.Queue)
                .HasColumnOrder(2)
                .HasColumnName("Queue")
                .HasColumnType("varchar(30)")
                .HasComment("Indica a fila que o equipamento escuta")
                .IsRequired();
            builder
                .Property(p => p.Port)
                .HasColumnOrder(3)
                .HasColumnName("Port")
                .HasColumnType("smallint")
                .HasComment("Para indicar a porta na qual o equipamento será acionado")
                .IsRequired();
            builder
                .Property(p => p.OnOff)
                .HasColumnOrder(4)
                .HasColumnName("OnOff")
                .HasColumnType("smallint")
                .HasComment("Para indicar se o equipamento está ligado ou desligado")
                .IsRequired();
            builder
                .Property(p => p.Active)
                .HasColumnOrder(5)
                .HasColumnName("Active")
                .HasColumnType("smallint")
                .HasComment("Para indicar se o equipamento está o o registro ativo")
                .IsRequired();

            builder
                 .HasOne(p => p.Customer)
                 .WithMany(p => p.Equipaments)
                 .HasForeignKey(p => p.CustomerId)
                 .HasConstraintName("fk_customer")
                 .IsRequired();

            builder
                .HasIndex(p => p.CustomerId)
                .HasDatabaseName("idx_customerid");

            builder
                .HasIndex(p => new
                    { p.Tag, p.Port })
                .HasDatabaseName("idx_tagcust_unique")
                .IsUnique();

            builder
                .ToTable("Equipament", "domain")
                .HasKey(c => c.Id)
                .HasName("pk_equipament");
        }
    }
}

