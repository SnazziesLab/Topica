using Events.Server.Data.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace Events.Server.Auth;

public class ApiKeyAuthorizationHandler : AuthorizationHandler<RoleRequirements>
{
    private readonly AuthDbContext _context;

    public ApiKeyAuthorizationHandler(AuthDbContext context)
    {
        _context = context;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirements roleRequirements)
    {
        var httpContext = context.Resource as HttpContext;
        if (httpContext == null)
        {
            return;
        }
        var requirement = context.Requirements.FirstOrDefault(e => e.GetType() == typeof(RolesAuthorizationRequirement)) as RolesAuthorizationRequirement;
        var requiredRoles = requirement?.AllowedRoles.ToArray();

        if (requiredRoles.IsNullOrEmpty())
        {
            context.Succeed(roleRequirements);
            return;
        }

        var userHasAllRoles = requiredRoles!.All(role => context.User.IsInRole(role));

        if (!userHasAllRoles)
        {
            context.Fail(new AuthorizationFailureReason(this, $"Does not have all the required roles {requiredRoles}"));
        }

        context.Succeed(roleRequirements);
    }
}

