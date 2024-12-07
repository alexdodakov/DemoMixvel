using DemoMixvel.Provider.One.Adapter;
using DemoMixvel.Provider.One.Models;
using DemoMixvel.Provider.Two.Adapter;
using DemoMixvel.Provider.Two.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMixvel.Controllers;

[ApiController]
[Route("provider-two/api/v{version:apiVersion}/")]
[ApiVersion("1.0")]
public class ProviderTwoController : Controller
{
    private readonly IProviderTwoAdapter _providerTwoAdapter;

    public ProviderTwoController(IProviderTwoAdapter providerOneAdapter)
    {
        _providerTwoAdapter = providerOneAdapter;
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping(CancellationToken cancellationToken)
    {
        var result = await _providerTwoAdapter.IsAvailableAsync(cancellationToken);
        return result
            ? StatusCode(200, new { message = "Ready" })
            : StatusCode(500, new { message = "Cannot access provider" });
    }

    [HttpPost("search")]
    public async Task<ActionResult<ProviderTwoSearchResponse>> Search(
    [FromBody] ProviderTwoSearchRequest request,
    CancellationToken cancellationToken)
    {
        var result = await _providerTwoAdapter.SearchAsync(request, cancellationToken);
        return Ok(result);
    }
}