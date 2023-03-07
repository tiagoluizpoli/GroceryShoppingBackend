using Contracts.Family;

namespace Contracts.Users;

public class UserResponseContract
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Enabled { get; set; }
    public FamilyResponseContract Family { get; set; }
}