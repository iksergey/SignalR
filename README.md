- [Introduction to SignalR](https://learn.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr)
- [ASP.NET Core SignalR supported platforms](https://learn.microsoft.com/en-us/aspnet/core/signalr/supported-platforms?view=aspnetcore-7.0)

В случае проблем с SSL-сертификатом
(Ошибка: `Unhandled exception. System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.`) 

В терминале выполнить `dotnet dev-certs https --trust` [подробнее](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs)

Инструкция:

- В корневой папке выполнить `dotnet restore`
- `cd Server && dotnet run`
- `cd ConsoleClient && dotnet run`

