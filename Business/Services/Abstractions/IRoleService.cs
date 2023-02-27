using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface IRoleService
    {
        Task<Guid> AddRoleByUser(Guid userID);
        Task<string> GetRoleByUser(User user);
    }
}
