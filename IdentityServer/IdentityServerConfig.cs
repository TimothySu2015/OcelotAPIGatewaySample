using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
               new ApiResource("api1","MyApi"),
               new ApiResource("api2","MyApi2")
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
                    AllowedScopes={ "api1","api2",IdentityServerConstants.StandardScopes.OfflineAccess //如果要獲取refresh_tokens ,必須在scopes中加上OfflineAccess
                    },
                    AllowOfflineAccess=true// 主要重新整理refresh_token,
        
                }
            };
        }
    }
}
