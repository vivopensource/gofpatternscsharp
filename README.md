# Design Patterns for C# (Gang of Four)

## Introduction

This repository focuses on providing the implementation of the design patterns mentioned by [Gang of Four](https://en.wikipedia.org/wiki/Design_Patterns) to solve common problems in software design.
It takes away the burden of writing the underlying code and executing the design patterns, and focus on the problem at hand,  i.e. using them straight away for creating a well designed and implemented software solution.

The patterns are provided in the most standard way possible, so that they can be easily understood and implemented.
There are examples provided for each of the design patterns, which can be used as a reference for understanding and implementing them (see  [Implementations](#Implementations) section).

## Usage

### Install

- Target frameworks: Net 6, Net 4.5
- Nuget package is available at: [GofPatterns](https://www.nuget.org/packages/GofPatterns/).

```bash
dotnet add package GofPatterns
```

### Execute

There are examples for each of the design patterns mentioned in [Implementations](#Implementations) section,
just click on the link to the design pattern and it will take you to the respective page of the design pattern that provides information and example.

## Implementations

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

### Creational Patterns

- [Factory](README/Creational/Factory.md)
- [Abstract Factory](README/Creational/AbstractFactory.md)
- [Builder](README/Creational/Builder.md)