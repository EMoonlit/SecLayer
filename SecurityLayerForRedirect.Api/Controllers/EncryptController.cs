using Microsoft.AspNetCore.Mvc;
using SecurityLayerForRedirect.Models;
using SecurityLayerForRedirect.Services.Interfaces;

namespace SecurityLayerForRedirect.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class EncryptController : ControllerBase
{
    
    private readonly ICryptService _cryptService;
    public EncryptController(ICryptService cryptService)
    {
        _cryptService = cryptService;
    }

    [HttpPost]
    public Task<IActionResult> Encrypt(
        [FromBody] EncryptedObjectRequest encryptedObjectRequest
        )
    {
        
        var result = _cryptService.Encrypt(encryptedObjectRequest.Uri.ToString());
        return Task.FromResult<IActionResult>(Ok(result));
    }
}