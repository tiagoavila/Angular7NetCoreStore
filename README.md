# Angular7NetCoreStore

Angular7NetCoreStore is a sample application using Angular7 at front-end, .NET Core 2.1 at back-end and SQL Server as database.

The goal of this project is to share knowledge with the technical community and work on some patterns, good practices and new technologies. 

## Architecture

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Repository pattern

## Technologies

* [.NET Core 2.2](https://dotnet.microsoft.com/download)
* [Entity Framework Core 2.2](https://docs.microsoft.com/en-us/ef/core)
* [AspNetCore Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio)
* [C# 7.3](https://docs.microsoft.com/en-us/dotnet/csharp)
* [ValueInjecter](https://github.com/omuleanu/ValueInjecter)
* [FluentValidation](https://fluentvalidation.net/)
* [Angular 7.2](https://angular.io/docs)
* [Typescript 3.2](https://www.typescriptlang.org/docs/home.html)
* [HTML](https://www.w3schools.com/html)
* [CSS](https://www.w3schools.com/css)
* [SASS](https://sass-lang.com)
* [JWT](https://jwt.io)

## Practices

* Clean Code
* SOLID Principles
* DDD (Domain-Driven Design)
* Commands and Handlers
* Inversion of Control
* Repository Pattern
* Database Migrations
* Authentication
* Auhorization

## How to use

After cloning or downloading the project you should be able to run it as soon as you configure the SQL Connection string and generate the database.

### Configure the SQL Connection string

1. In your SQL Server create an empty database called AngularNetCoreStoreDB

2. Open the `appsettings.json` in `Angular7NetCoreStore.WebAPI` and change the DefaultConnection to match with your SQL Server configuration

### Generate the tables

Now you need to generate the Domain and Identity tables.

1. Set `Angular7NetCoreStore.WebAPI` as Startup Project and make sure that the connection string is correct.

2. Open your `Package Manager Console`, set `Angular7NetCoreStore.Infra.Data` as Default project and run the following command:
```
    Update-Database -Verbose -Context Angular7NetCoreStoreContext
```

3. Now set `Angular7NetCoreStore.Infra.CrossCutting.Identity` as the Default project and run the command:
```
    Update-Database -Verbose -Context ApplicationDbContext
```

If everything was right you have the tables created successfully.

### Running the project

1. On Visual Studio 2017, run the project `Angular7NetCoreStore.WebAPI`.

2. On VSCode, open the folder `Angular7NetCoreStoreApp`, then open your command prompt under this folder and run 
```
    npm install
```

3. After install all Angular dependencies, run the command: 
```
    ng serve -o
``` 

And the project should be running for you test the features.
