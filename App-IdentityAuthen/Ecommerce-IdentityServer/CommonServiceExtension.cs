
using System.Collections.Generic;
using System.Reflection;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce_IdentityServer
{
    public static class CommonServiceExtension
    {
        public static List<TestUser> GetUsers(){
            return new List<TestUser>
            {
                new TestUser(){
                    SubjectId = "1",
                    Username = "Han",
                    Password = "password"
                },
                new TestUser(){
                    SubjectId = "2",
                    Username = "Test",
                    Password = "password2"
                }
            };
        }
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>{
                    new ApiResource{
                        Name = "ecommerceApp",
                        DisplayName = "ecommerceApp API",
                        Description = "Allow the application to access ecommerceApp API on your behalf",
                        Scopes = new List<string> {"ecommerceApp.read", "ecommerceApp.write"},
                        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    },
                };
        }

       public static IEnumerable<ApiScope> ApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope("ecommerceApp.read", "Read Access to API #1"),
			    new ApiScope("ecommerceApp.write", "Write Access to API #1")
            };


        public static IEnumerable<Client> GetClients(string secretKey) {
            return  new List<Client>{
                    new Client{
                        ClientId = "client_id",
                        ClientSecrets = { new Secret(secretKey.ToSha256())},
                        AllowedGrantTypes =  GrantTypes.ClientCredentials,
                        AllowedScopes = { "ecommerceApp.read" } 
                    },
                    new Client{
                        ClientId = "ro.client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = { new Secret(secretKey.ToSha256())},
                        AllowedScopes = { "ecommerceApp.read" } 
                    }
                };
        }

         public static List<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(), // <-- usefull
                    new IdentityResources.Email(),
                    new IdentityResource
                    {
                        Name = "role",
                        UserClaims = new List<string> {"role"}
                    }
                };
            }      
    }
}