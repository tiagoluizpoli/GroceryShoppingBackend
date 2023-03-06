using Contracts.Family;

namespace Contracts.Users;

public class NewUserContract
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string Email { get; set; }
    public Guid? FamilyId { get; set; }
    public NewFamilyContract? Family { get; set; }
}