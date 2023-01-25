using HardTrain.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardTrain.BLL.Models;

public record TrainingViewModel : TrainingUpdateModel
{
    public string Title { get; init; }
    public string Description { get; init; }
    public Category Category { get; init; }

}
