# Wilcommerce.Core.Data.EFCore
Contains an implementation of the [Wilcommerce.Core](https://github.com/wilcommerce/Wilcommerce.Core) packages using Entity Framework Core as persistence framework.

## Requirements
According to Entity Framework Core 3.0 requirements, this project is built using NETStandard 2.1 as Target Framework (See [https://docs.microsoft.com/it-it/ef/core/what-is-new/ef-core-3.0/breaking-changes#netstandard21](https://docs.microsoft.com/it-it/ef/core/what-is-new/ef-core-3.0/breaking-changes#netstandard21) for further informations).

This means it will not run on projects which target .NET Framework.

If you have some specific needs you can [open a issue on GitHub](https://github.com/wilcommerce/Wilcommerce.Core.Data.EFCore/issues) or you can consider to [contribute to Wilcommerce](CONTRIBUTING.md).

## Installation

Nuget package available here 

[https://www.nuget.org/packages/Wilcommerce.Core.Data.EFCore](https://www.nuget.org/packages/Wilcommerce.Core.Data.EFCore)

## Usage
Add the the EventsContext class to your ASP.NET Core project.
```<C#>
services.AddDbContext<EventsContext>(options => 
    options.UseSqlServer("[ConnectionStringName]",
    b => b.MigrationAssembly("[Your assembly name]")));
```
The EventsContext is injected in the EventStore implementation.

After the DbContext has been registered in the ServiceCollection, you need to add a migration using **donet** CLI or the **Package Manager Console**.
```
// Using dotnet CLI
dotnet ef migrations add -c Wilcommerce.Core.Data.EFCore.EventsContext Initial

// Using Package Manager Console
EntityFrameworkCore\Add-Migration -Context Wilcommerce.Core.Data.EFCore.EventsContext Initial
```

After this, you can update your database:
```
// Using dotnet CLI
dotnet ef database update -c Wilcommerce.Core.Data.EFCore.EventsContext

// Using Package Manager Console
EntityFrameworkCore\Update-Database -Context Wilcommerce.Core.Data.EFCore.EventsContext
```

## EventStore Component
The EventStore class is the Entity Framework Core implementation of the [IEventStore](https://github.com/wilcommerce/Wilcommerce.Core/blob/master/src/Wilcommerce.Core.Infrastructure/IEventStore.cs) interface.

It provides the methods to persist all the events occurred.
It requires a EventsContext instance as constructor parameter.

# Contributing
If you want to contribute to Wilcommerce please, check the [CONTRIBUTING](CONTRIBUTING.md) file.