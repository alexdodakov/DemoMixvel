using DemoMixvel.Provider.One.Adapter;
using DemoMixvel.Provider.One.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMixvel.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("provider-one/api/v{version:apiVersion}/")]
public class ProviderOneController : Controller
{
    private readonly IProviderOneAdapter _providerOneAdapter;

    public ProviderOneController(IProviderOneAdapter providerOneAdapter)
    {
        _providerOneAdapter = providerOneAdapter;
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping(CancellationToken cancellationToken)
    {
        var result = await _providerOneAdapter.IsAvailableAsync(cancellationToken);
        return result 
            ? StatusCode(200, new { message = "Ready" }) 
            : StatusCode(500, new { message = "Cannot access provider" }); 
    }

    [HttpPost("search")]
    public async Task<ActionResult<ProviderOneSearchResponse>> Search(
    [FromBody] ProviderOneSearchRequest request,
    CancellationToken cancellationToken)
    {
        var result = await _providerOneAdapter.SearchAsync(request, cancellationToken);
        return Ok(result);
    }
}