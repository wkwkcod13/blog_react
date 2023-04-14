using blog_api.Extensions;
using blog_api.Handler;
using Microsoft.AspNetCore.Antiforgery;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var signKey = builder.Configuration.GetValue<string>("JwtSettings:SignKey");
var encryKey = builder.Configuration.GetValue<string>("JwtSettings:EncryKey");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(CustomCors.DefaultCorsOptions(MyAllowSpecificOrigins));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(CustomAuthentication.DefaultAuthenticationOptions)
    .AddJwtBearer(CustomAuthentication.DefaultBearerOptions(signKey, encryKey));

builder.Services.AddCustomServiceCollection();
builder.Services.AddAuthorization(CustomAuthorization.DefaultAuthorizationOptions);

builder.Services.AddAntiforgery(options => { options.HeaderName = "X-CSRF-TOKEN"; });

builder.Services.AddSwaggerGen(CustomSwaggerGen.DefaultSwaggerGenOptions);
builder.Services.AddSwaggerGen(CustomSwaggerGen.JwtBearerSwaggerGenOptions);
builder.Services.AddSwaggerGen(CustomSwaggerGen.CsrfSwaggerGenOptions);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
