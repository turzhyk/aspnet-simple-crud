using EmployeeStore.Core.Models;
using EmployeeStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeStore.DataAccess.Repos;



public class EmployeesRepository : IEmployeesRepository
{
    private readonly EmployeeStoreDbContext _context;

    public EmployeesRepository(EmployeeStoreDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> GetById(Guid id)
    {
        var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e=> new Employee(e.Id, e.Login, e.PasswordHash,e.FullName)).SingleOrDefaultAsync();
        if (employee != null)
            return employee;
        else
        {
            throw new Exception($"Employee with id {id} not found");
        }
    }
    public async Task Create(Employee employee)
    {
        var employeeEntity = new EmployeeEntity(employee.Id, employee.Login, employee.PasswordHash, employee.FullName);
        await _context.Employees.AddAsync(employeeEntity);
        await _context.SaveChangesAsync();
    }
}