

using Microsoft.AspNetCore.Cors.Infrastructure;
using SignalR_Test.DataAccess.Context;
using SignalR_Test.DataAccess.Repository;
using SignalR_Test.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
//builder.Services.AddSignalR().AddStackExchangeRedis("");

builder.Services.AddDbContext<MyContext>();

builder.Services.AddScoped<IUserRepository,UserRepository>();

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

app.Run();


