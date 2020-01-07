using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer
{
    public class ResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName == "test" && context.Password == "test")
            {
                context.Result = new GrantValidationResult(
                 subject: context.UserName,
                 claims:new Claim[] { new Claim(ClaimTypes.NameIdentifier,"Tester") },
                 authenticationMethod: OidcConstants.AuthenticationMethods.Password);
            }
            else
            {
                //驗證失敗
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "invalid custom credential"
                    );
            }
            return Task.FromResult(0);
        }
    }
}
