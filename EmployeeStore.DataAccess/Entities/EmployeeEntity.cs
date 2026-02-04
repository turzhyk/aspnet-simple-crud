namespace EmployeeStore.DataAccess.Entities;

public class EmployeeEntity
{
    public Guid Id { get; }
    public string Login { get; }
    public string PasswordHash { get; private set; }
    public string FullName { get; }
    
    public EmployeeEntity(Guid id, string login, string passwordHash, string fullName)
    {
        Id = id;
        Login = login;
        PasswordHash = passwordHash;
        FullName = fullName;
    }
}