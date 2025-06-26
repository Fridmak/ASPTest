var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.MapGet("/sex", ([AsParameters] Person person) => $"You would like to fuck {person.name} who is {person.age} y.o.");
app.MapGet("/", () => "main");

app.Use(async (context, next) => { await next(); await context.Response.WriteAsync("added"); });
app.UseStaticFiles();

app.Run();

public class Person
{
    public string name { get; set; }
    public int age { get; set; }
}