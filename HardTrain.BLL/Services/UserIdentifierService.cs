using HardTrain.BLL.Abstractions;
using HardTrain.DAL.Entities.UserResultScope;
using SharedPackages.ResponseResultCore.Exceptions;

namespace HardTrain.BLL.Services;

public class UserIdentifierService : IUserIdentifierService
{
    public User? _currentUser { get; private set; }

    public void SetCurrentUser(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));

        if (_currentUser is not null)
            throw new InvalidOperationException("User already set.");

        _currentUser = user;
    }

    public User? GetCurrentUserOrDefault()
        => _currentUser;

    public User GetCurrentUser()
        => GetCurrentUserOrDefault()
            ?? throw new BadRequestException("Server could not determine the user, please check this request header: Authorization");
}

