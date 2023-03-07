using Domain.Common.Errors.BaseErrors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
namespace Api.Web.Controllers;

[Route("api/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ApiController
{
    [Route("error")]
    [AllowAnonymous]
    public IActionResult Error()
    {
        ErrorOr<string> response = BaseErrors.DefaultErrors.UnhandledError;
        return response.Match(Ok, Problem);
    }
}