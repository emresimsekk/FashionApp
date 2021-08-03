// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FashionApp.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_FashionApp_Api")
                {
                    Scopes={ "api_FashionApp_FullPermission" }
                },

                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
              

            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
                new ApiScope("api_FashionApp_FullPermission","FashionApp için tüm izinler"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
           };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // MobileClient_CC client credentials flow client
                new Client
                {
                    ClientId = "MobileClient_CC",
                    ClientName = "MobileClient CC",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secretCC".Sha256()) },
                    AllowedScopes = { IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "MobileClient_ROP",
                    ClientName = "MobileClient ROP",

                    ClientSecrets = { new Secret("secretROP".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api_FashionApp_FullPermission"
                    },
                    AccessTokenLifetime=(int) (DateTime.Now.AddMinutes(10)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse,

                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int) (DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,

                },
            };
    }
}