using System;
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
