using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinancialControll.Models
{
    public class UserClaim : UserClaimsPrincipalFactory<Profile>
    {
        public UserClaim(UserManager<Profile> userManager, IOptions<IdentityOptions> optionsAccessor):base(userManager,optionsAccessor)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Profile user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Member", user.Member));
            return identity;
        }

    }
}
