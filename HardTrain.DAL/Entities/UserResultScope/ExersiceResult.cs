using HardTrain.DAL.Entities.ExersiceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.DAL.Entities.UserResultScope
{
    public class ExersiceResult
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ExersiceId { get; set; }
        [ForeignKey("ExersiceKey")]
        public Exersice Exersice { get; set; }

        public Guid TrainingId { get; set; }
        [ForeignKey("TrainingKey")]
        public Training TrainingResult { get; set; } 
    }
}
