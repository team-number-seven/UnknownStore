using System.Collections.Generic;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using ApiResource = IdentityServer4.EntityFramework.Entities.ApiResource;
using ApiScope = IdentityServer4.EntityFramework.Entities.ApiScope;
using Client = IdentityServer4.EntityFramework.Entities.Client;
using IdentityResource = IdentityServer4.EntityFramework.Entities.IdentityResource;

namespace UnknownStore.DAL.Data.InitData
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new IdentityServer4.Models.ApiResource("UnknownStore.WebAPI", "Unknown Store API").ToEntity()
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.Profile().ToEntity(),
                new IdentityResources.OpenId().ToEntity(),
                new IdentityResources.Email().ToEntity()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new IdentityServer4.Models.ApiScope("UnknownStore.WebAPI", "Unknown Store API").ToEntity()
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new IdentityServer4.Models.Client
                {
                    ClientId = "Store react client",
                    ClientName = "React client",
                    RequirePkce = false,
                    ClientUri = "http://localhost:3000",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RedirectUris = {"http://localhost:3000/callback","http://localhost:3000/refresh"},
                    PostLogoutRedirectUris = {"http://localhost:3000/app"},
                    AllowedCorsOrigins = {"http://localhost:3000"},
                    AllowedScopes = {"openid", "profile", "UnknownStore.WebAPI"},
                    AllowAccessTokensViaBrowser = true
                }.ToEntity()
            };
    }
}