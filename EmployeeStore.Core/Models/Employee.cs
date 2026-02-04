namespace EmployeeStore.Core.Models;

public class Employee
{
    public Guid Id { get; }
    public string Login { get; }
    public string PasswordHash { get; private set; }
    public string FullName { get; }

    public Employee(Guid id, string login, string passwordHash, string fullName)
    {
        Id = id;
        Login = login;
        PasswordHash = passwordHash;
        FullName = fullName;
    }

    public void UpdatePassword(string newPassword)
    {
        PasswordHash = newPassword;
    }
}