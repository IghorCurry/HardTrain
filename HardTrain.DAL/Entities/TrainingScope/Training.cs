using HardTrain.DAL.Enums;

namespace HardTrain.DAL.Entities.TrainingScope
{
    public class Training
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TrainingExersice> TrainingExersices { get; set; } = new List<TrainingExersice>();
    }
}
