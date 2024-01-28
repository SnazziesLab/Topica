using Microsoft.AspNetCore.Identity;

namespace Events.Server.Services
{
    public class UserManager
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UserManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateUserWithRoles(string username, string password, string[] roles)
        {
            var user = new IdentityUser
            {
                UserName = username,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user, password);

            //foreach (var role in roles)
            //{
            //    await _userManager.AddToRoleAsync(user, role);
            //}
        }

    }
}
