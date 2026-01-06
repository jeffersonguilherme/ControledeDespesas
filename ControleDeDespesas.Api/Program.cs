using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Application.Services;
using ControleDeDespesas.Domain.Repositories.Interfaces;
using ControleDeDespesas.Domain.Services;
using ControleDeDespesas.Infrastructure.Identity;
using ControleDeDespesas.Infrastructure.Data;
using ControleDeDespesas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ControleDeDespesas.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});//Conexão com o banco por meio do Entity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //Configurações para deixar a senha menos segura, 
    // só usar no inicio do desevolvimento par teste 
    // iniciais remover quando for para teste automatizados e final do projeto
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()//A forma que vai ser pestistido no banco
.AddDefaultTokenProviders();
     //Informa que estarei usando ApplicatioUser 
    // como base para o usuarios e que estarrei usando Roles

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
