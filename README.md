# Wilcommerce.Core.Data.EFCore
Contains an implementation of the [Wilcommerce.Core](https://github.com/wilcommerce/Wilcommerce.Core) packages using Entity Framework Core as persistence framework.

## Installation

Nuget package available here 

[https://www.nuget.org/packages/Wilcommerce.Core.Data.EFCore](https://www.nuget.org/packages/Wilcommerce.Core.Data.EFCore)

## Usage
Add the the EventsContext class to your project.
```<C#>
services.AddDbContext<EventsContext>(options => // Specify your provider);
```
The EventsContext is injected in the EventStore implementation

## EventStore Component
The EventStore class is the Entity Framework Core implementation of the [IEventStore](https://github.com/wilcommerce/Wilcommerce.Core/blob/master/src/Wilcommerce.Core.Infrastructure/IEventStore.cs) interface.

It provides the methods to persist all the events occurred.
It requires a EventsContext instance as constructor parameter.

# Contributing
If you want to contribute to Wilcommerce please, check the [CONTRIBUTING](CONTRIBUTING.md) file.