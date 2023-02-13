using HardTrain.BLL.Abstractions;
using HardTrain.DAL.Entities.UserResultScope;
using SharedModules.Infrastructure.Identity.Abstractions;

namespace HardTrain.WebApi.Middlewares;

public class UserIdentifierMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public UserIdentifierMiddleware(RequestDelegate next, ILogger<UserIdentifierMiddleware> logger)
        => (_next, _logger) = (next, logger);

    public async Task InvokeAsync(
        HttpContext context,
        IIdentityManager<User> identityManager,
        IUserIdentifierService userIdentifierService)
    {
        await Identify(context, identityManager, userIdentifierService);
        await _next(context);
    }

    private async Task Identify(HttpContext httpContext, IIdentityManager<User> identityManager, IUserIdentifierService userIdentifierService)
    {
        try
        {
            var user = await identityManager.GetUserOrDefaultAsync(httpContext.User);

            //Skip identificating if user is not authenticated
            if (user is null)
                return;

            userIdentifierService.SetCurrentUser(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while identifying user");

            throw;
        }
    }
}

