using HardTrain.DAL.Entities.UserResultScope;

namespace HardTrain.BLL.Abstractions
{
    public interface IUserIdentifierService
    {
        public User? _currentUser { get; }

        void SetCurrentUser(User user);
        User GetCurrentUser();
        User? GetCurrentUserOrDefault();
    }
}