using System;
using Microsoft.IdentityModel.Tokens;

namespace AbpKendoDemo.Web.Authentication.JwtBearer
{
    public class TokenProviderOptions
    {
        public string Path { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}