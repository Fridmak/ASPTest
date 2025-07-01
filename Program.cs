using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("person.json");
builder.Services.Configure<Person>(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<PersonMiddleware>();
app.Run();
public class PersonMiddleware
{
    private readonly RequestDelegate _next;
    public Person Person { get; }
    public PersonMiddleware(RequestDelegate next, IOptions<Person> options)
    {
        _next = next;
        Person = options.Value;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        System.Text.StringBuilder stringBuilder = new();
        stringBuilder.Append($"<p>Name: {Person.Name}</p>");
        stringBuilder.Append($"<p>Age: {Person.Age}</p>");
        stringBuilder.Append("</ul>");

        await context.Response.WriteAsync(stringBuilder.ToString());
    }
}
public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; } = 0;
}

//52