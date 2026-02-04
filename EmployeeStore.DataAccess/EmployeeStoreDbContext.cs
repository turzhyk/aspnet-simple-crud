using EmployeeStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeStore.DataAccess;

public class EmployeeStoreDbContext:DbContext
{
    public EmployeeStoreDbContext(DbContextOptions<EmployeeStoreDbContext> options):base(options)
    {
            
    }

    public DbSet<EmployeeEntity> Employees { get; set; }
}