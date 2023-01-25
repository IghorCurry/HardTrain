using HardTrain.DAL.Entities.ExersiceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.DAL.Entities.UserResultScope
{
    public class TrainingResult
    {

        public Guid Id { get; set; }

        public DateTime ExecutionDate { get; set; }

        public Guid TrainingResultId { get; set; }

        public Training Training { get; set; }

    }
}

