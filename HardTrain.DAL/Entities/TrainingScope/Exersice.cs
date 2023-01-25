using System.ComponentModel.DataAnnotations;
using HardTrain.DAL.Enums;

namespace HardTrain.DAL.Entities.ExersiceEntities;

public class Exersice
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public Category Category { get; set; }

    public string Description { get; set; }

}
