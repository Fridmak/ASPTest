using EMPTYASP;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

builder.Configuration.AddJsonFile("person.json");
var tom = new Person();
app.Configuration.Bind(tom);

app.Run(async (context) => await context.Response.WriteAsync($"{tom.Name} - {tom.Age}"));

app.Run();

public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; } = 0;
}