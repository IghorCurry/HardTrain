using System.ComponentModel.DataAnnotations;


namespace HardTrain.DAL.Entities.ExersiceEntities;

public class Exersice
{
    public int Id { get; set; }

    public string Title { get; set; }

    public Category Category { get; set; }

    public string Description { get; set; }

}
