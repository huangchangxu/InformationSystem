﻿

using System;
using static IdentityServer4.IdentityServerConstants;

namespace InformationPlat.Id4Server.Entities
{
    public abstract class Secret
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; } = SecretTypes.SharedSecret;
    }
}