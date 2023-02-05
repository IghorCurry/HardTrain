using Microsoft.AspNetCore.Identity;
using SharedModules.Infrastructure.Identity.Abstractions;

namespace HardTrain.DAL.Entities.UserResultScope;

public partial class User : IdentityUser<Guid>, IUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<TrainingResult> TrainingResults { get; set; } = new List<TrainingResult>();
}