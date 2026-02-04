using EmployeeStore.Core.Models;

namespace EmployeeStore.DataAccess.Repos;

public interface IEmployeesRepository
{
    Task<Employee> GetById(Guid id);
    Task Create(Employee employee);
}