var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<IHelloService, RuHelloService>();
builder.Services.AddTransient<IHelloService, EnHelloService>();

var app = builder.Build();

app.UseMiddleware<HelloMiddleware>();

app.Run();


interface IHelloService
{
    string Message { get; }
}

class RuHelloService : IHelloService
{
    public string Message => "Привет METANIT.COM";
}
class EnHelloService : IHelloService
{
    public string Message => "Hello METANIT.COM";
}

class HelloMiddleware
{
    readonly IHelloService helloService;

    public HelloMiddleware(RequestDelegate _, IHelloService helloServices)
    {
        this.helloService = helloServices;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        string responseText = "";
        responseText += $"<h3>{helloService.Message}</h3>";
       
        await context.Response.WriteAsync(responseText);
    }
}