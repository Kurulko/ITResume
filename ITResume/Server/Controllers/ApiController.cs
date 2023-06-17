using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    protected async Task<IActionResult> ReturnOkIfEverithingIsGood(Func<Task> action)
    {
        try
        {
            await action();
            return Ok();
        }
        catch (Exception ex)
        {
            var innerEx = ex.InnerException;
            return BadRequest((innerEx is null ? ex : innerEx).Message);
        }
    }
}