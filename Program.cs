using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/test", testApp =>
{
    testApp.Use(async (context, next) =>
    {
        Console.WriteLine("→ In middleware branch '/test'");
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("Middleware branch: /test");
        await next();
        Console.WriteLine("← In middleware branch '/test'");
    });
});

app.Map("/test", () =>
{
    Console.WriteLine("🎯 Minimal route '/test' is executing");
    return "Minimal route: /test";
});

app.Run();