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
        private readonly ICountryService countryService;
        public UserService(IUnitOfWork unitOfWork, AppDbContext dbContext = null, IRoleService roleService = null, ICountryService countryService = null)
        {
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;
            this.roleService = roleService;
            this.countryService = countryService;
        }

        public async Task<UserTokenDTO> Login(UserLoginDTO userLogin)
        {
            try
            {
                var User = await unitOfWork.GetRepository<User>().GetAsync(x => x.UserName == userLogin.UserName);
                var user = await roleService.GetRoleByUser(User);
                if (userLogin.UserToken != null)
                {
                    if (User.UserToken == userLogin.UserToken)
                    {
                        UserTokenDTO userTokenDTO = new UserTokenDTO()
                        {

                            UserId = User.UserId,
                            UserToken = userLogin.UserToken,
                        };

                        return userTokenDTO;

                    }

                    if (User.Password == userLogin.Password)
                    {
                        if (user != "Hatalı rol Bilgisi")
                        {
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
                            UserTokenDTO userTokenDTO = new UserTokenDTO()
                            {

                                UserId = User.UserId,
                                UserToken = userToken,
                            };
                           
                            return userTokenDTO;
                        }
                    }
                    return null;
                }
                else
                {
                    if (User.Password == userLogin.Password)
                    {
                        if (user != "Hatalı rol Bilgisi")
                        {
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
                            UserTokenDTO userTokenDTO = new UserTokenDTO()
                            {

                                UserId = User.UserId,
                                UserToken = userToken,
                            };
                            
                            return userTokenDTO;
                        }
                    }
                    return null;

                }
            }
            catch
            {
                return null;
            }
            
            
            

           

        }

        public async Task<RegisterDTO> Register(UserDTO user)
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
           var role= await roleService.AddRoleByUser(user1.UserId);
            await unitOfWork.SaveAsync();
            var country = await countryService.GetCountry(user.CountryId);
            return new RegisterDTO
            {
                UserId = user1.UserId,
                UserFirstName = user1.UserFirstName,
                UserLastName = user1.UserLastName,
                UserName = user1.UserName,
                UserToken = user1.UserToken,
                CountryImgUrl = country.CountryImageUrl,
                RoleId=role
            };
        }
    

        public async Task<User> GetUser(Guid userId)
        {
            var user=await unitOfWork.GetRepository<User>().GetByGuidAsync(userId);
            return user;
        }
    }
}
