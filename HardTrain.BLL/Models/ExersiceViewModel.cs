using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models
{
    public record ExersiceViewModel : ExersiceUpdateModel
    {
        public DateTime CrearedAt { get; init; }
        public DateTime ModifieAt { get; init; }
    }
}
