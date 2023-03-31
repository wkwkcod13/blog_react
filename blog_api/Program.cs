using blog_api.Handler;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var signKey = builder.Configuration.GetValue<string>("JwtSettings:SignKey");
var encryKey = builder.Configuration.GetValue<string>("JwtSettings:EncryKey");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(CustomCors.DefaultCorsOptions(MyAllowSpecificOrigins));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(CustomAuthentication.DefaultAuthenticationOptions)
    .AddJwtBearer(CustomAuthentication.DefaultBearerOptions(signKey, encryKey));

builder.Services.AddAuthorization(CustomAuthorization.DefaultAuthorizationOptions);
builder.Services.AddCustomServiceCollection();
builder.Services.AddSwaggerGen(CustomSwaggerGen.DefaultSwaggerGenOptions);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
