using System.Collections.Generic;
using System.Security.Claims;
using DevResume.Domain.Entities;

namespace DevResume.ServiceLayer.Services
{
    public class UserClaimsProvider : IUserClaimsProvider
    {
        public List<Claim> GenerateClaims(ApplicationUser user)
        {
            return new List<Claim>()
            {
                new Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };
        }
    }
}