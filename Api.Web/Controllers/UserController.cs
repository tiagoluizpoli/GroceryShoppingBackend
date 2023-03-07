using Application.Services.Interfaces;
using Contracts.Users;
using Domain.GlobalConstants;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route($"{ApiVersions.ApiV1}[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddUser(NewUserContract user)
    {
        var response = await _userService.AddUser(user);
        if (response != null)
        {
            return Ok(response);
        }

        return BadRequest();
    }
}