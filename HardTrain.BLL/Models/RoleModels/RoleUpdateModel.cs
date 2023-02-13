using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models.RoleModels
{
    public record RoleUpdateModel : RoleCreateModel
    {
        public Guid Id { get; init; }
    }
}

