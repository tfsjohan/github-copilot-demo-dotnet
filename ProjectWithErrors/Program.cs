using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DemoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Register the circular dependencies
builder.Services.AddTransient<A>();
builder.Services.AddTransient<B>();

var app = builder.Build();

app.MapGet("/", (A aInstance) => {
    aInstance.DoSomething();
    return "Hello World!";
});

app.Run();