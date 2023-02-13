namespace HardTrain.BLL.Models.UserModels
{
    public record UserCreateModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public IEnumerable<string> Roles { get; init; } = new List<string>();

        //public ICollection<TrainingResult> TrainingResults { get; init; }
    }
}
