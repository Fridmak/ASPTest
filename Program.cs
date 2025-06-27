using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Configuration["sekas"] = "no";

app.Map("/", (IConfiguration appConfig) => $"{appConfig["sekas"]} - {appConfig["age"]}");
app.Run();