// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("apis", "Access to APIs"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                    {
                        ClientId = "postman",
                        ClientName = "Postman client application using client credentials",
                        ClientSecrets = { new Secret("secret".Sha256()) },
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = { "apis" },
                    },
                new Client
                    {
                        ClientId = "console",
                        ClientName = "Console client application using client credentials",
                        ClientSecrets = { new Secret("secret".Sha256()) },
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = { "apis" },
                    }
            };
    }
}