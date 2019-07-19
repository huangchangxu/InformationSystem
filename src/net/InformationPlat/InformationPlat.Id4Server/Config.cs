﻿using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationPlat.Id4Server
{
    public class Config
    {
        /// <summary>
        /// 定义api信息
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>{
             new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    //没有交互式用户，使用clientid / secret进行身份验证
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //秘密认证
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //客户端可以访问的范围
                    AllowedScopes = { "api1" }
                }
            };
        }
    }
}
