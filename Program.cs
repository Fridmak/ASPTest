using EMPTYASP;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

builder.Configuration.AddTextFile("sources.txt");

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();