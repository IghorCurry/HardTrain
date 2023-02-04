using HardTrain.DAL.Entities.TrainingScope;

namespace HardTrain.DAL.Entities.UserResultScope
{
    public class TrainingResult
    {

        public Guid Id { get; set; }

        public DateTime ExecutionDate { get; set; }

        public Guid TrainingId { get; set; }

        public Training Training { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Note { get; set; }//updatemodel1

        public ICollection<ExersiceResult> ExersiceResults { get; set; }

    }
}

