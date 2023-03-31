using Microsoft.AspNetCore.Authorization;

namespace blog_api.Handler
{
    public static class CustomAuthorization
    {
        public static Action<AuthorizationOptions> DefaultAuthorizationOptions = options =>
        {
            options.AddPolicy("RequireAdminRole", policy =>
            {
                policy.RequireRole("admin");
            });
            options.AddPolicy("RequireUserRole", policy =>
            {
                policy.RequireRole("user");
            });
        };
    }
}
