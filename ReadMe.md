# .NET-Logging-Extensions

Additions and extensions for .NET logging.

[![NuGet](https://img.shields.io/nuget/v/RegionOrebroLan.Logging.svg?label=NuGet)](https://www.nuget.org/packages/RegionOrebroLan.Logging)

## 1 Information

For the moment this solution only contains extensions for ILogger, [LoggerExtension](/Source/Project/Extensions/LoggerExtension.cs):

- LogDebugIfEnabled
- LogInformationIfEnabled
- etc

The reason is "prestanda". Do not do anything more if the log-level is not enabled. I haven't found so much about it, except here:

- https://stackoverflow.com/questions/44585112/ilogger-asp-net-core-log-is-called-even-isenabled-return-false

I am not sure if this is necessary, but anyhow. Doing the check everywhere in your code always needs an extra line of code to check if it is enabled. So if we have an extension-method for it we can do it with a one-liner.

## 2 Links

- [High-performance logging with LoggerMessage in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage?view=aspnetcore-6.0)
- [High-Performance Logging in .NET Core](https://www.stevejgordon.co.uk/high-performance-logging-in-net-core)