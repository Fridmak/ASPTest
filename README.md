# ASPTest

Эксперименты с внутренностями ASP.NET Core: собственный провайдер конфигурации,
файловый логгер и минимальный HTTP-конвейер.

## Стек

- .NET 8, ASP.NET Core
- `IConfigurationSource` / `IConfigurationProvider`
- `ILoggerProvider` / `ILogger`
- Minimal API

## Что внутри

- `TextConfigurationProvider` и `TextConfigurationSource` — читают настройки
  из текстового файла `sources.txt` и добавляют их в общую конфигурацию.
- `TextConfigurationExtensions` — удобное подключение провайдера через `AddTextFile`.
- `FileLoggerProvider` и `Logger` — пишут логи в `logger.txt`.
- `person.json` — пример данных для конфигурации.
- `wwwroot` — статические страницы.
- `Program.cs` — минимальный пайплайн с обработкой исключения.

## Зачем это

Понять, как на самом деле работают `IConfiguration` и `ILogging` в ASP.NET Core:
не «магия DI», а набор провайдеров, источников и фабрик. Свой провайдер — самый
быстрый способ разобраться.

## Как запустить

```bash
dotnet run
```

Приложение поднимается на порту из `Properties/launchSettings.json`.
Логи пишутся в `logger.txt` в корне проекта.

## Чему научился

- Реализовать `IConfigurationSource` и `IConfigurationProvider` и подключить их
  через собственный extension-метод `AddTextFile`.
- Написать `ILoggerProvider`, который пишет в файл, и встроить его в общий pipeline.
- Читать исходники ASP.NET Core и повторять механизм в коде, а не догадываться о нём.
