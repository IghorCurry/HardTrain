using HardTrain.DAL.Entities.UserResultScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models.UserModels;

public class UserUpdateModel : UserCreateModel 
{
    public Guid Id { get; init; }
}
