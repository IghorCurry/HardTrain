using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardTrain.DAL.Entities.ExersiceEntities
{
    public class TrainingExersice
    {
        [Key]
        public Guid Id { get; set; }

        public int Weight { get; set; }

        public int Reps { get; set; }

        public int Time { get; set; }

        public Guid ExersiceId { get; set; }
        [ForeignKey("ExersiceKey")]
        public Exersice Exersice { get; set; }

        public Guid TrainingId { get; set; }
        [ForeignKey("TrainingKey")]
        public Training Training { get; set; }

    }
}
