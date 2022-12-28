using grpcbackend;
using grpcbackend.Services;
using grpcbackend.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddGrpc();
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = $"https://dev-x7ujf-k7.us.auth0.com";
    options.Audience = builder.Configuration.GetSection("Auth0").GetValue("Audience", "");

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };

});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("consume:app", policy => policy.Requirements.Add(new HasScopeRequirement("consume:app", "https://dev-x7ujf-k7.us.auth0.com/")));
    options.AddPolicy("manage:app", policy => policy.Requirements.Add(new HasScopeRequirement("manage:app", "https://dev-x7ujf-k7.us.auth0.com/")));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
builder.Services.AddSingleton<DB>();


var app = builder.Build();

app.MapGrpcService<FileService>();
app.MapGrpcService<NoteService>();
app.MapGet("/", () => "Hello there!");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
