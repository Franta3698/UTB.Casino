using Microsoft.AspNetCore.Identity;
using UTB.Casino.Domain.Entities.Interfaces;
namespace UTB.Casino.Infrastructure.Identity;



public class User : IdentityUser<int>, IUser<int>
{
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
}
