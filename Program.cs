using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/html")),

    RequestPath = new PathString("/pages")
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),

    RequestPath = new PathString("/pages")
});

app.MapGet("/sex", ([AsParameters] Person person) => $"You would like to fuck {person.name} who is {person.age} y.o.");

app.Run();

public class Person
{
    public string name { get; set; }
    public int age { get; set; }
}