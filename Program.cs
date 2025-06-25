var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseToken(); // ← используем наше middleware

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();



// ========== MIDDLEWARE ==========
public class TokenMiddleware
{
    private readonly RequestDelegate _next;

    public TokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];

        if (token != "12345678")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Token is invalid");
            return; // ❗ важно: выходим, не вызывая next
        }

        await _next(context); // ✅ продолжаем pipeline
    }
}


// ========== РАСШИРЕНИЕ ==========
public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenMiddleware>();
    }
}