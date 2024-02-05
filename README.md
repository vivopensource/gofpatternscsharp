# Design Patterns for C# (Gang of Four)

## Introduction

This repository provides the implementation of the design patterns mentioned 
by the [Gang of Four](https://en.wikipedia.org/wiki/Design_Patterns) for C#,
to solve common problems in software design.
It takes away the burden of writing the underlying code for the design patterns, and focus on the problem at hand,
i.e. using the patterns straight away for developing a well designed software solution.

It contains the ready-made classes and interfaces of the design patterns.
They are written in the most standard way possible so that they can be easily understood and implemented.
There are examples provided for each patterns provided by the library,
and these example are referred for understanding and using them appropriately
(see [Available Patterns](#available-patterns) section).

## Usage

### Install

- Target frameworks: Net 6, Net 4.5
- Nuget package is available at: [GofPatterns](https://www.nuget.org/packages/GofPatterns/).

```bash
dotnet add package GofPatterns
```

### Execute

There are examples for each of the design patterns mentioned in [Available Patterns](#available-patterns) section,
just click on the link of the design pattern to go to the respective page of the design pattern that provides information and example.

## Available Patterns

### Behavioral Patterns

- [Chain of Responsibility - CoR](README/Behavioral/CoR.md)
- [Command](README/Behavioral/Command.md)
- [State](README/Behavioral/State.md)
- [Strategy](README/Behavioral/Strategy.md)
- [Mediator](README/Behavioral/Mediator.md)
- [Observer](README/Behavioral/Observer.md)

### Structural Patterns

- [Proxy](README/Structural/Proxy.md)
- [Decorator](README/Structural/Decorator.md)
- [Adapter](README/Structural/Adapter.md)
- [Flyweight](README/Structural/Flyweight.md)
- [Bridge](README/Structural/Bridge.md)

### Creational Patterns

- [Factory](README/Creational/Factory.md)
- [Abstract Factory](README/Creational/AbstractFactory.md)
- [Builder](README/Creational/Builder.md)


## Code coverage

- The code coverage is exceptional for the library, and the examples provided for each pattern
- The library is tested for all the patterns, and the examples are also tested for the patterns they are demonstrating.

### Result

To view the coverage result please see the Actions tab of the repository.