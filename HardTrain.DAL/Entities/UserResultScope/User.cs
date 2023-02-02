using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.DAL.Entities.UserResultScope
{
    public class User
    {
        public Guid Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public ICollection<TrainingResult> TrainingResults { get; set; }
    }
}
