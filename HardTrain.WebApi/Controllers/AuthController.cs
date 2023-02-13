using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModules.Infrastructure.Identity.Abstractions;
using SharedModules.Infrastructure.Identity.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace HardTrain.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthManager _authManager;

    public AuthController(IAuthManager authManager)
    {
        _authManager = authManager;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenPairModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        try
        {
            return Ok(await _authManager.Login(loginModel));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("refresh-token-pair")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenPairModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshTokenPair(RefreshTokenPairModel model)
    {
        return Ok(await _authManager.RefreshTokenPair(model.AccessToken, model.RefreshToken));
    }


    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ForgotPassword([EmailAddress] string email)
    {
        await _authManager.ForgotPasswordAsync(email);

        return Ok("If your email address exists in our database, you will receive a password recovery link at your email address in a few minutes.");
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        return Ok(await _authManager.ResetPasswordAsync(model));
    }

}