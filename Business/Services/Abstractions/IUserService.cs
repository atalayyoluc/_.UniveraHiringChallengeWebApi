using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserTokenDTO> Login(UserLoginDTO userLogin);
        Task<RegisterDTO> Register(UserDTO user);
        Task<User> GetUser(Guid userId);
    }
}
