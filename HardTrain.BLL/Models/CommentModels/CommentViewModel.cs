namespace HardTrain.BLL.Models.CommentModels
{
    public record CommentViewModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public Guid UserId { get; init; }
        public string UserName { get; init; }
        public Guid PostId { get; init; }
    }
}
