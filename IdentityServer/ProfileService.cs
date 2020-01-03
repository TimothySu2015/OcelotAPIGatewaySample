using System;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServer
{
    public class ProfileService:IProfileService
    {

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if(context.Caller==IdentityServerConstants.ProfileDataCallers.UserInfoEndpoint)
            {
                context.IssuedClaims = new System.Collections.Generic.List<System.Security.Claims.Claim>()
               {
                   new System.Security.Claims.Claim ("AAA","12345")
               };
            }

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}
