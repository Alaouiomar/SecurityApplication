using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SecurityApp.Data;
using SecurityApp.Models;
using System.Security.Claims;

namespace SecurityApp.Authorize
{
    public class FirstNameAuthHandler : AuthorizationHandler<FirstNameAuthRequirement>

    {
        public UserManager<ApplicationUser> _userManager { get; set; }
        public SecurityAppDbContext _db { get; set; }


        public FirstNameAuthHandler(UserManager<ApplicationUser> userManager, SecurityAppDbContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FirstNameAuthRequirement requirement)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _db.applicationUser.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var firstNameClaim = _userManager.GetClaimsAsync(user)
                    .GetAwaiter().GetResult()
                    .FirstOrDefault(u => u.Type == "FirstName");

                if (firstNameClaim != null)
                {
                    if (firstNameClaim.Value.ToLower().Contains(requirement.Name.ToLower()))
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
