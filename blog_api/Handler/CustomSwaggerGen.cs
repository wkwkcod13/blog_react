using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace blog_api.Handler
{
    public static class CustomSwaggerGen
    {
        public static Action<SwaggerGenOptions> DefaultSwaggerGenOptions = options =>
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
    }
}
