# Wilcommerce.Core.Data.EFCore
Contains an implementation of the [Wilcommerce.Core](https://github.com/wilcommerce/Wilcommerce.Core) packages using Entity Framework Core as persistence framework.

## Installation

Nuget package available here 

[https://www.nuget.org/packages/Wilcommerce.Core.Data.EFCore](https://www.nuget.org/packages/Wilcommerce.Core.Data.EFCore)

## Usage
Add the CommonContext class to your project.

For example in an ASP.NET Core project add this line to the ConfigureServices method in Startup.cs
```<C#>
services.AddDbContext<CommonContext>(options => // Specify your provider);
```
The CommonContext is injected in the read model component and the Repositoryimplementation.

If you need to persists the events using Entity Framework Core, add the EventsContext class to your project.
```<C#>
services.AddDbContext<EventsContext>(options => // Specify your provider);
```
The EventsContext is injected in the EventStore implementation

## Read model Component
The CommonDatabase class is the Entity Framework Core implementation of the [ICommonDatabase](https://github.com/wilcommerce/Wilcommerce.Core/blob/master/src/Wilcommerce.Core.Common/Domain/ReadModels/ICommonDatabase.cs) interface.

It provides a facade to access all the readonly data.
It requires an instance of CommonContext as constructor parameters.

## Repository Component
The Repository class is the Entity Framework Core implementation of the [IRepository](https://github.com/wilcommerce/Wilcommerce.Core/blob/master/src/Wilcommerce.Core.Common/Domain/Repository/IRepository.cs) interface.

It provides all the methods useful for persist an Aggregate model. 
It requires a CommonContext instance as constructor parameter.

## EventStore Component
The EventStore class is the Entity Framework Core implementation of the [IEventStore](https://github.com/wilcommerce/Wilcommerce.Core/blob/master/src/Wilcommerce.Core.Infrastructure/IEventStore.cs) interface.

It provides the methods to persist all the events occurred.
It requires a EventsContext instance as constructor parameter.

# Contributing
If you want to contribute to Wilcommerce please, check the [CONTRIBUTING](CONTRIBUTING.md) file.