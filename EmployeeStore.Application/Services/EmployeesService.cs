using EmployeeStore.Core.Models;
using EmployeeStore.DataAccess.Repos;

namespace EmployeeStore.Application.Services;

public class EmployeesService
{
    private readonly IEmployeesRepository _repo;

    public EmployeesService(IEmployeesRepository repo)
    {
        _repo = repo;
    }

    public async Task CreateEmployee(string login, string password, string fullName)
    {
        if (password.Length < 8)
            throw new ArgumentException("Password is less than 8 characters");
        if (!password.Any(char.IsDigit))
            throw new ArgumentException("Password does not contain any digits");
        var _password = password;
        
        await _repo.Create(new Employee(Guid.NewGuid(), login, _password, fullName));
    }
}