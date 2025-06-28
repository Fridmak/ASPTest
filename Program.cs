var builder = WebApplication.CreateBuilder();
var app = builder.Build();

builder.Configuration.AddJsonFile("settings.json");

app.Map("/", (IConfiguration appConfig) => $"{appConfig["person"]} - {appConfig["age"]}");

app.Run();