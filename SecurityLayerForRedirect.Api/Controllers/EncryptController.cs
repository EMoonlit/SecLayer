// using System.Security.Cryptography;
// using Microsoft.AspNetCore.Mvc;
// using SecurityLayerForRedirect.Models;
// using SecurityLayerForRedirect.Services;
//
// namespace SecurityLayerForRedirect.Api.Controllers;
//
// [ApiController]
// [Route("v1/[controller]")]
// public class EncryptController : ControllerBase
// {
//     private readonly EncryptService _encryptService;
//     private static readonly RSACryptoServiceProvider _csp = new(2048);
//     private readonly RSAParameters _publicKey = _csp.ExportParameters(false);
//     private readonly RSAParameters _privateKey = _csp.ExportParameters(true);
//     public EncryptController()
//     {
//         _encryptService = new EncryptService(_csp, _publicKey);
//     }
//
//     [HttpPost]
//     public Task<IActionResult> Encrypt(
//         [FromBody] EncryptedObjectRequest encryptedObjectRequest
//         )
//     {
//         var result = _encryptService.Encrypt(encryptedObjectRequest.Uri.ToString());
//         return Task.FromResult<IActionResult>(Ok(result));
//     }
// }