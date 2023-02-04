namespace HardTrain.DAL.Entities.UserResultScope
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<TrainingResult> TrainingResults { get; set; }
    }
}
