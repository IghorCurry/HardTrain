using HardTrain.DAL.Entities.TrainingScope;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardTrain.DAL.Entities.UserResultScope
{
    public class ExersiceResult
    {
        public Guid Id { get; set; }

        public Guid ExersiceId { get; set; }
        public Exersice Exersice { get; set; }

        public int Weight { get; set; }

        public int Reps { get; set; }

        public int Time { get; set; }

        public Guid TrainingResultId { get; set; }
        public TrainingResult TrainingResult { get; set; }
    }
}
