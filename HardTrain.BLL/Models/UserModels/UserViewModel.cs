using HardTrain.BLL.Models.TrainingResultModels;

namespace HardTrain.BLL.Models.UserModels
{
    public record UserViewModel : UserUpdateModel
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public ICollection<TrainingResultViewModel> TrainingResults { get; init; } = new List<TrainingResultViewModel>();
        public IEnumerable<string> Roles { get; init; } = new List<string>();

    }
}
