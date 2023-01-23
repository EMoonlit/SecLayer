using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using SecurityLayerForRedirect.Models;
using SecurityLayerForRedirect.Services;

namespace SecurityLayerForRedirect.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class DecryptController : ControllerBase
{
    private readonly DecryptService _decryptService;

    public DecryptController(DecryptService decryptService)
    {
        _decryptService = decryptService;
    }

    [HttpPost]
    public Task<IActionResult> Encrypt(
        [FromBody] DecryptedObjectRequest decryptedObjectRequest
        )
    {
        var result = _decryptService.Decrypt(decryptedObjectRequest.PlainText);
        return Task.FromResult<IActionResult>(Ok(result));
    }
}