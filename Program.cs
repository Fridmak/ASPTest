var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<ICounter, Counter>();
builder.Services.AddScoped<CounterService>();

var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();

public interface ICounter
{
    int Value { get; }
}

public class Counter : ICounter
{
    static Random rnd = new Random();
    private int _value;
    public Counter()
    {
        _value = rnd.Next(0, 1000000);
    }
    public int Value
    {
        get => _value;
    }
}

public class CounterService
{
    public ICounter Counter { get; }
    public CounterService(ICounter counter)
    {
        Counter = counter;
    }
}


public class CounterMiddleware
{
    RequestDelegate next;

    int i = 0;
    public CounterMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ICounter counter, CounterService counterService)
    {
        i++;
        httpContext.Response.ContentType = "text/html;charset=utf-8";
        await httpContext.Response.WriteAsync($"Запрос {i}; Counter: {counter.Value}; Service: {counterService.Counter.Value}");
    }
}
