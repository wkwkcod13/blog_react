using iText.Kernel.XMP.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace blog_api.Handler
{
    public static class CustomSwaggerGen
    {
        public static Action<SwaggerGenOptions> DefaultSwaggerGenOptions = options =>
        {
            options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
        };

        public static Action<SwaggerGenOptions> JwtBearerSwaggerGenOptions = options =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                BearerFormat = "JWT",
                Scheme = "bearer",
                Description = "Enter your JWT token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
            };
            options.AddSecurityDefinition("Bearer", securityScheme);
            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            };
            options.AddSecurityRequirement(securityRequirement);
        };

        public static Action<SwaggerGenOptions> GoogleSwaggerGenOptions = options =>
        {
            OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/auth"),
                        TokenUrl = new Uri("https://oauth2.googleapis.com/token"),
                        Scopes = new Dictionary<string, string>()
                        {
                            { "openid", "OpenID" },
                            { "profile", "Profile" },
                            { "email", "Email" }
                        }
                    }
                }
            };
            options.AddSecurityDefinition("Google", openApiSecurityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Google"
                        }
                    }, new string[]{ }
                }
            });
        };

        public static Action<SwaggerGenOptions> CsrfSwaggerGenOptions = options =>
        {
            options.OperationFilter<AddHeaderOperationFilter>("X-CSRF-TOKEN", "");
        };
    }
}
