namespace HardTrain.BLL.Models.PostModels
{
    public record PostViewModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public string ImageURL { get; init; }
    }
}
