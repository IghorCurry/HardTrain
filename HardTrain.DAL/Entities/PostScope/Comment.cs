using HardTrain.DAL.Entities.UserResultScope;

namespace HardTrain.DAL.Entities.PostScope
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
