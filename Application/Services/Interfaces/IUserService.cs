using Contracts.Users;
using ErrorOr;

namespace Application.Services.Interfaces;

public interface IUserService
{
    Task<ErrorOr<UserResponseContract>> AddUser(NewUserContract request);
    Task<ErrorOr<List<UserResponseContract>>> GetUsers();
}