var builder = WebApplication.CreateBuilder();

var app = builder.Build();

var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
app.UseStaticFiles();

app.MapGet("/sex", ([AsParameters] Person person) => $"You would like to fuck {person.name} who is {person.age} y.o.");
//app.MapGet("/", () => "main");

app.Run();

public class Person
{
    public string name { get; set; }
    public int age { get; set; }
}