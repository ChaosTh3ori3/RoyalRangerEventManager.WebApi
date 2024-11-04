using System.IdentityModel.Tokens.Jwt;
using RangerEventManager.Persistence.Entities.User;
using RangerEventManager.WebApi.Repositories;

namespace RangerEventManager.WebApi.Services.UserService
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public string GetCurrentUserFromHttpContext(HttpContext context)
        {       
            var token = (string)context.Request.Headers["Authorization"]!;

            if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer ")) 
                return string.Empty;
            
            token = token.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                
            return jsonToken!.Claims.First(x => x.Type == "preferred_username").Value;

        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await userRepository.GetUsers();
        }
    }
}
