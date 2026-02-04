using EmployeeStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeStore.DataAccess.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Login).IsRequired();
        builder.Property(e => e.PasswordHash).IsRequired();
        builder.Property(e => e.FullName).IsRequired();
    }
}