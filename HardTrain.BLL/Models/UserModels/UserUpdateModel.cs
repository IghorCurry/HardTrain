namespace HardTrain.BLL.Models.UserModels;

public record UserUpdateModel : UserCreateModel
{
    public Guid Id { get; init; }
}
