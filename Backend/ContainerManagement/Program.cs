using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string bearer = "Bearer";

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition(bearer, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = bearer
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = bearer
            },
            Scheme = "oauth2",
            Name = bearer,
            In = ParameterLocation.Header,
        },
        new List<string>()
        }
    });
});

// Remove the repository registration as it's now handled manually via Singleton in the Facades
//builder.Services.AddTransient<IContainerRepository, ContainerRepository>();
//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IContainerTypeRepository, ContainerTypeRepository>();
//builder.Services.AddTransient<IContainerStatusRepository, ContainerStatusRepository>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod().AllowAnyOrigin();
    });
});

// JWT Bearer token authentication setup
var key = Encoding.ASCII.GetBytes(ContainerManagement.Key.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();
app.UseAuthentication(); // Ensure authentication is applied
app.UseAuthorization();

app.MapControllers();

app.Run();
