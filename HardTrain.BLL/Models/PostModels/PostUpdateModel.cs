namespace HardTrain.BLL.Models.PostModels
{
    public record PostUpdateModel : PostCreateModel
    {
        public Guid Id { get; init; }
    }
}
