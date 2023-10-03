

using System.Net;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using SignalR_Test.DataAccess.Context;
using SignalR_Test.DataAccess.Repository;
using SignalR_Test.Hubs;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR().AddStackExchangeRedis("localhost:9191,password=8492");

builder.Services.AddDbContext<MyContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    }));

var app = builder.Build();

app.UseCors("CorsPolicy");

app.MapHub<TestHub>("/Hub");

Console.WriteLine("Enter Port :");
string port = Console.ReadLine();

app.Run($"http://localhost:{port}");
