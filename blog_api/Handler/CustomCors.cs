using Microsoft.AspNetCore.Cors.Infrastructure;

namespace blog_api.Handler
{
    public static class CustomCors
    {
        public static Action<CorsOptions> DefaultCorsOptions(string name)
        {
            Action<CorsOptions> option = options =>
            {
                options.AddPolicy(name, policy =>
                {
                    policy.WithOrigins("https://localhost:3000", "*");
                });
            };
            return option;
        }
    }
}
