using Application.Services.Interfaces;
using Contracts.Users;
using Domain.GlobalConstants;
using ErrorOr;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route($"{ApiVersions.ApiV1}[Controller]")]
public class UserController : ApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetUsers()
    {
        var response = await _userService.GetUsers();
        return response.Match(Ok, Problem);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddUser(NewUserContract user)
    {
        ErrorOr<UserResponseContract> response = await _userService.AddUser(user);
        return response.Match(Ok, Problem);
    }
}