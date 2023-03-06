using Contracts.Users;

namespace Application.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseContract> AddUser(NewUserContract request);
}