using System.Collections;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace Project1.AuthServer
{
    //TODO: Update this file with correct config for your specific project
    /// <summary>
    /// The following is some data for use with in memory configuration, this data is typically pulled from a database.
    /// </summary>
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis => new List<ApiResource>
        {
            new ApiResource("api1", "My API")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client()
            {
                ClientId = "mvc",
                
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                
                ClientSecrets =
                {
                    new Secret("secret".Sha256()) // TODO: this acts as the password for the client update it
                },
                
                AllowedScopes =
                {
                    "api1"
                }
            }
        };
        
        
    }
}