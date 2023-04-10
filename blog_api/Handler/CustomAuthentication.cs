using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace blog_api.Handler
{
    public static class CustomAuthentication
    {
        public static Action<AuthenticationOptions> DefaultAuthenticationOptions = options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        };

        public static Action<JwtBearerOptions> DefaultBearerOptions(string signKey, string encryKey)
        {
            Action<JwtBearerOptions> options = options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey)),
                    TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encryKey))
                };
            };
            return options;
        }

        public static Action<GoogleOptions> GoogleOAuthOptions()
        {
            Action<GoogleOptions> options = options =>
            {
                options.ClientId = "570305887147-u1e7hmkimcd99tls16f7npunatl2r7f2.apps.googleusercontent.com";
                options.ClientSecret = "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";
            };
            return options;
        }
    }
}
