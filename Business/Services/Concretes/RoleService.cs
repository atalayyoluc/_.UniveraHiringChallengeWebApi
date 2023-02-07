using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Concretes
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddRoleByUser(Guid userID)
        {
            UserRole userRole = new UserRole()
            {
                RoleId = Guid.Parse("233f4064-1f5d-4b71-9009-0a928a15669f"),
                UserId = userID
            };

             await unitOfWork.GetRepository<UserRole>().AddAsync(userRole);
        }

        public async Task<string> GetRoleByUser(User user)
        {
            try
            {
                var role = await unitOfWork.GetRepository<UserRole>().GetAllAsync(x => x.UserId == user.UserId,x => x.Role);
                if (role != null)
                {
                    return role[0].Role.RoleName;
                }
            }
            catch 
            {
                return "Hatalı rol Bilgisi";
            }
            return "Hatalı rol Bilgisi";
        }
    }
}
