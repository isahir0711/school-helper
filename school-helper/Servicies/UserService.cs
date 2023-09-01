using Microsoft.AspNetCore.Identity;
using school_helper.Entities;

namespace school_helper.Servicies
{
    public interface IUserService
    {
        Task<string> GetUserIdAsync();
    }
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(UserManager<IdentityUser> userManager,IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetUserIdAsync()
        {
            var email = httpContextAccessor.HttpContext.User.Claims
                .Where(claim => claim.Type == "email").FirstOrDefault().Value;
            var user = await userManager.FindByEmailAsync(email);
            return user.Id;
        }
    }
}
