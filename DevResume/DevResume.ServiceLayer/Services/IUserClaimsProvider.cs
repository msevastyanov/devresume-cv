using System.Collections.Generic;
using System.Security.Claims;
using DevResume.Domain.Entities;

namespace DevResume.ServiceLayer.Services
{
    public interface IUserClaimsProvider
    {
        List<Claim> GenerateClaims(ApplicationUser user);
    }
}