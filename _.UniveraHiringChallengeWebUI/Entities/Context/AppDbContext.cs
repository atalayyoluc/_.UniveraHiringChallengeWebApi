using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace _.UniveraHiringChallengeWebUI.Entities.Context
{
    public class AppDbContext: IdentityDbContext<AppUser,AppRole,Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UniveraUser;Trusted_Connection=True;");
        }
    }
}
