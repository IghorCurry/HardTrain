using HardTrain.DAL.Enums;

namespace HardTrain.DAL.Entities.TrainingScope;

public class Exersice
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    public int DefaultWeight { get; set; }

    public int DefaultReps { get; set; }

    public int DefaultTime { get; set; }
    public Category Category { get; set; }

    public string Description { get; set; }

}
