# Music Store

Example application for testing patterns, libraries, and app modernization techniques. The application is based on the [MVC Music Store](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-1) tutorial application from way back in the ASP.NET Framework MVC days, and will be gradually upgraded to become a modern cloud-native application.

## Getting Started

For now, the project is a .NET Framework application so will require Visual Studio on a PC to run.

Open MusicStore.sln in Visual Studio. Ensure MusicStore.Web is set to the default project.

Create a *ConnectionStrings.user.config* file in the root of the Web project with the following content:

```xml
<connectionStrings>
  <clear />
  <add name="MusicStoreEntities" connectionString="" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Add your SQL Server connection string. For local development, SQL Server LocalDB can be used with the following connection string - `Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=MusicStore;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\MusicStore.mdf`

To run the application, either `F5` or `ctrl+F5` depending on whether or not you want to debug.

## Roadmap

The project is currently based off of the old .NET Framework based application and has a long way to go to make it a modern application fit for 2026. There are a number of steps currently on the roadmap:

* Add unit tests for the current application
* Migrate to .NET 10
* Refactor back end to use clean architecture-like architecture
* Containerise application
* IaC templates to deploy infrastructure
* Migrate web application framework from MVC to Blazor
* Containerise application
* Add UI and integration tests
