using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfig
{
    public class TaskEntityConfig : IEntityTypeConfiguration<ScheduleTask>
    {
        public void Configure(EntityTypeBuilder<ScheduleTask> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(0)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasComment("Chave para identificar a tarefa");
            builder
                .Property(p => p.TaskName)
                .HasColumnOrder(1)
                .HasColumnName("TaskName")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Nome para identificar nome tarefa");
            builder
                .Property(p => p.Action)
                .HasColumnOrder(2)
                .HasColumnName("Action")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("Ação para identificar comportamento da placa");
            builder
                .Property(p => p.Expression)
                .HasColumnOrder(4)
                .HasColumnName("Expression")
                .HasColumnType("varchar") //00 20 * * 5
                .IsRequired()
                .HasMaxLength(30)
                .HasComment("Expressão cron para a programação");
            builder
                .Property(p => p.TaskJobId)
                .HasColumnOrder(5)
                .HasColumnName("TaskJobId")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasComment("Identificação da task cadastrada");

            builder
                 .HasOne(p => p.Equipament)
                 .WithMany(p => p.Tasks)
                 .HasForeignKey(p => p.EquipamentId)
                 .HasConstraintName("fk_equip_task")
                 .IsRequired();

            builder
                .HasIndex(p => new
                { p.Action, p.Expression, p.EquipamentId })
                .HasDatabaseName("idx_task_unique")
                .IsUnique();

            builder
                .ToTable("Task", "domain")
                .HasKey(c => c.Id)
                .HasName("pk_task");
        }
    }
}

