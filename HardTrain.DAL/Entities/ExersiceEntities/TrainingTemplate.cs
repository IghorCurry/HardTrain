using System.ComponentModel.DataAnnotations;

namespace HardTrain.DAL.Entities.ExersiceEntities
{
    public class TrainingTemplate
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Order { get; set; }

        public string Description { get; set; }
    }
}
