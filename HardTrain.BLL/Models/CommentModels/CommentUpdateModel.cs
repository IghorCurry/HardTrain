namespace HardTrain.BLL.Models.CommentModels
{
    public record CommentUpdateModel : CommentCreateModel
    {
        public Guid Id { get; init; }
    }
}
