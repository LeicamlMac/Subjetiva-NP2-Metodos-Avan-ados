// Program.cs
using BigDaddyBackend.Application.Commands;
using BigDaddyBackend.Infrastructure.Data;
using BigDaddyBackend.Infrastructure.Repositories;
using BigDaddyBackend.Domain.Interfaces;
using BigDaddyBackend.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// === Serviços ===
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// === CONEXÃO COM MySQL (phpMyAdmin) ===
var connectionString = "Server=localhost;Database=bigdaddy_burgers;User=root;Password=;Port=3306;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()));

// === Dependency Injection ===
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderFactory, OrderFactory>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));

// === CORS (para seu frontend) ===
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// === Pipeline ===
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

// === Cria o banco e tabelas automaticamente (se não existirem) ===
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.EnsureCreated();

app.Run();