using System.ComponentModel.DataAnnotations;

namespace HardTrain.DAL.Entities.ExersiceEntities
{
    public class Training
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
