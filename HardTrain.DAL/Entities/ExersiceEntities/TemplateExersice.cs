using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardTrain.DAL.Entities.ExersiceEntities
{
    public class TemplateExersice
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public int Weight { get; set; }

        public int Reps { get; set; }

        public int Time { get; set; }

        public int ExersiceId { get; set; }
        [ForeignKey("ExersiceKey")]
        public Exersice Exersice { get; set; }

        public int TrainingTemplateId { get; set; }
        [ForeignKey("TrainingTemplateKey")]
        public TrainingTemplate TrainingTemplate { get; set; }
    }
}
