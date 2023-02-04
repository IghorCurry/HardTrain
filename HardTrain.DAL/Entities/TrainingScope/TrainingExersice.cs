namespace HardTrain.DAL.Entities.TrainingScope
{
    public class TrainingExersice
    {
        public Guid Id { get; set; }


        public Guid ExersiceId { get; set; }
        public Exersice Exersice { get; set; }

        public Guid TrainingId { get; set; }
        public Training Training { get; set; }

    }
}
