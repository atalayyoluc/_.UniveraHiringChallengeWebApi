using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeData.Context;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace _.UniveraHiringChallengeBusines.Services.Concretes
{
    
    public class UserService : IUserService
    {
        private readonly IRoleService roleService;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext dbContext;
        public UserService(IUnitOfWork unitOfWork, AppDbContext dbContext = null, IRoleService roleService = null)
        {
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;
            this.roleService = roleService;
        }

        public async Task<string> Login(string userName,string password)
        {
            try
            {
                var User = await unitOfWork.GetRepository<User>().GetAsync(x => x.UserName == userName);
             
                var user = await roleService.GetRoleByUser(User);
                    if (User.Password == password)
                    {
                    if (user!= "Hatalı rol Bilgisi") {
                        List<Claim> claimss = new List<Claim>();
                        claimss.Add(new Claim(ClaimTypes.Name, User.UserName));
                        claimss.Add(new Claim(ClaimTypes.NameIdentifier, User.UserName));
                        claimss.Add(new Claim(ClaimTypes.Role, user)); 

                        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Convert.FromBase64String("AtalayAtalayAtalayAtalayAtalay12"));
                        SigningCredentials signing = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                            issuer: "localhost",
                            audience: "localhost",
                            claims: claimss,
                            signingCredentials: signing,
                            expires: DateTime.Now.AddDays(30)
                            );
                        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                        string userToken = tokenHandler.WriteToken(jwtSecurityToken);
                        return userToken;
                    }
                    return "Lütfen Hesabınızı Onaylatın";
                    }
                return "Giriş Bilgileri Hatalı";


             }
            catch
            {
                return "Giriş Bilgileri Hatalı";
            }
            
            
            

           

        }

        public async Task Register(UserDTO user)
        {
            User user1 = new User()
            {
                UserId = Guid.NewGuid(),
                UserName = user.UserName,
                Password = user.Password,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                CountryId = user.CountryId,
            };
            await unitOfWork.GetRepository<User>().AddAsync(user1);
            await roleService.AddRoleByUser(user1.UserId);
            await unitOfWork.SaveAsync();
        }
    }
}
