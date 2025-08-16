using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfig
{
    public class UserCustomerEntityConfig : IEntityTypeConfiguration<UserCustomer>
    {
        public void Configure(EntityTypeBuilder<UserCustomer> builder)
        {
            builder.HasKey(p => p.Id);

            // relacionamento com User (1:1)
            builder
                .HasOne(p => p.User)
                .WithOne(p => p.UserCustomer)
                .HasForeignKey<UserCustomer>(p => p.UserId)
                .HasConstraintName("fk_user_usercustomer")
                .IsRequired();

            // relacionamento com Customer (1:1)
            builder
                .HasOne(p => p.Customer)
                .WithOne(p => p.UserCustomer)
                .HasForeignKey<UserCustomer>(p => p.CustomerId)
                .HasConstraintName("fk_customer_usercustomer")
                .IsRequired();

            builder
                .ToTable("UserCustomer", "domain")
                .HasKey(c => c.Id)
                .HasName("pk_usercustomer");
        }
    }
}

