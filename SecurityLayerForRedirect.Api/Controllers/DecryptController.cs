// using Microsoft.AspNetCore.Mvc;
// using SecurityLayerForRedirect.Models;
// using SecurityLayerForRedirect.Services;
//
// namespace SecurityLayerForRedirect.Api.Controllers;
//
// [ApiController]
// [Route("v1/[controller]")]
// public class DecryptController : ControllerBase
// {
//     private readonly DecryptService _decryptService;
//
//     public DecryptController(DecryptService decryptService)
//     {
//         _decryptService = decryptService;
//     }
//
//     [HttpPost]
//     public Task<IActionResult> Decrypt(
//         [FromBody] DecryptedObjectRequest decryptedObjectRequest
//         )
//     {
//         var result = _decryptService.Decrypt(decryptedObjectRequest.PlainText);
//         return Task.FromResult<IActionResult>(Ok(result));
//     }
// }

using Microsoft.AspNetCore.Mvc;
using SecurityLayerForRedirect.Models;
using SecurityLayerForRedirect.Services.Interfaces;

namespace SecurityLayerForRedirect.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class DecryptController : ControllerBase
{
    
    private readonly ICryptService _cryptService;
    public DecryptController(ICryptService cryptService)
    {
        _cryptService = cryptService;
    }

    [HttpPost]
    public Task<IActionResult> Decrypt(
        [FromBody] DecryptedObjectRequest decryptedObjectRequest
    )
    {
        
        var result = _cryptService.Decrypt(decryptedObjectRequest.PlainText);
        return Task.FromResult<IActionResult>(Ok(result));
    }
}