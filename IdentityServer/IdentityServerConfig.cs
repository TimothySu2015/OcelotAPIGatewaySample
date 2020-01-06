using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class IdentityServerConfig
    {
        public static object JwtClaimtypes { get; private set; }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
               new ApiResource("PaymentService","Payment Service"),
               new ApiResource("ProductService","Product Service")
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            var openIdScope = new IdentityResources.OpenId();

            return new List<IdentityResource>
            {
                openIdScope,
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client(){
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets=
                    {
                      new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "PaymentService","ProductService",
                        IdentityServerConstants.StandardScopes.OfflineAccess, //如果要獲取refresh_tokens ,必須在scopes中加上OfflineAccess
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId
                    },
                    AllowOfflineAccess=true// 主要重新整理refresh_token,
        
                }
            };
        }
    }
}
