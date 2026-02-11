using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Application.Services;
using ControleDeDespesas.Domain.Repositories.Interfaces;
using ControleDeDespesas.Domain.Services;
using ControleDeDespesas.Infrastructure.Data;
using ControleDeDespesas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ControleDeDespesas.Infrastructure.Services;
using ControleDeDespesas.Infrastructure.Identity;
using ControleDeDespesas.Infrastructure.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Digite: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();


builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IExpenseAppService, ExpenseAppService>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<IPaymentMethodAppService, PaymentMethodAppService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});//Conexão com o banco por meio do Entity


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
   //Regras de senha
   options.Password.RequireDigit = true;
   options.Password.RequireNonAlphanumeric = false;
   options.Password.RequireUppercase = false;
   options.Password.RequireLowercase = false;
   options.Password.RequiredLength = 6;

   options.User.RequireUniqueEmail = true;

   options.Lockout.MaxFailedAccessAttempts = 5;
   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); 
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwt.Issuer,

        ValidateAudience = true,
        ValidAudience = jwt.Audience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        RoleClaimType = ClaimTypes.Role
    };
});


builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddDataProtection();


builder.Services.AddScoped<DapperContext>(); // Conexão com banco por meio do Dapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
