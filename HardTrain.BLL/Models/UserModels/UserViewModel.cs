using HardTrain.DAL.Entities.UserResultScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models.UserModels
{
    public class UserViewModel : UserUpdateModel
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public ICollection<TrainingResult> TrainingResults { get; init; }

    }
}
