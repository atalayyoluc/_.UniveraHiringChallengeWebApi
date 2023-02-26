using _.UniveraHiringChallengeEntity.DTOs;
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
        Task<string> GetRoleByUser(User user);
        Task<Guid> AddRoleByUser(Guid userID);
    }
}
