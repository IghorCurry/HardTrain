using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models
{
    public record ExersiceUpdateModel : ExersiceCreateModel
    {
        public Guid Id { get; init; }
    }
}
