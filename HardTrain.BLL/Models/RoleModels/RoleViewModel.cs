using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models.RoleModels
{
    public record RoleViewModel 
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
