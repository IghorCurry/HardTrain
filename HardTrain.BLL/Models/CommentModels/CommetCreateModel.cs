namespace HardTrain.BLL.Models.CommentModels
{
    public record CommentCreateModel
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
    }
}
