using Microsoft.AspNetCore.Authorization;

namespace Events.Server.Auth
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public List<string> RolesList { get; set; }

        public CustomAuthorizeAttribute(params string[] roles)
        {
            RolesList = roles.ToList();
        }
    }

}
