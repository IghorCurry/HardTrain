using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModules.Infrastructure.Identity.Abstractions;
using SharedModules.Infrastructure.Identity.Models.Auth;
using SharedPackages.ResponseResultCore.Models;
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
    [ProducesResponseType(typeof(HttpResponseResult<TokenPairModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var httpResponseResult = new HttpResponseResult<TokenPairModel>
        {
            Data = await _authManager.Login(loginModel)
        };
        return StatusCode(httpResponseResult.StatusCode, httpResponseResult);
    }

    [HttpPost("refresh-token-pair")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(HttpResponseResult<TokenPairModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshTokenPair(RefreshTokenPairModel model)
    {
        var httpResponseResult = new HttpResponseResult<TokenPairModel>
        {
            Data = await _authManager.RefreshTokenPair(model.AccessToken, model.RefreshToken)
        };
        return StatusCode(httpResponseResult.StatusCode, httpResponseResult);
    }


    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ForgotPassword([EmailAddress] string email)
    {
        await _authManager.ForgotPasswordAsync(email);

        var httpResponseResult = new HttpResponseResult<bool>
        {
            Data = true,
        };

        httpResponseResult.AddInformationMessage("If your email address exists in our database, you will receive a password recovery link at your email address in a few minutes.");

        return StatusCode(httpResponseResult.StatusCode, httpResponseResult);
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(HttpResponseResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseResult<object>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        var httpResponseResult = new HttpResponseResult<bool>
        {
            Data = await _authManager.ResetPasswordAsync(model)
        };
        return StatusCode(httpResponseResult.StatusCode, httpResponseResult);
    }

}