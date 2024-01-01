
# Decorator Pattern

- The decorator pattern is a structural design pattern that allows behavior to be added to an individual object, dynamically, without affecting the behavior of other objects from the same class.
- The decorator pattern is often useful for adhering to the Single Responsibility Principle, as it allows functionality to be divided between classes with unique areas of concern.

## Structure

- It consists of component, concrete component, decorator and concrete decorator.
- Component: An interface that will contain the method to be implemented by the concrete component and decorator.
- Concrete Component: A class that will contain the actual implementation of the method.
- Decorator: A class that will contain the reference to the component and will implement the same interface implemented by the component so that it can be used by the client.


## Examples

### Type 1: Execute pattern without input

#### Code

```csharp
// TODO: Code
```
```
// TODO: Output
```

#### Full example

[DecoratorPatternExampleNoInput](./../../GofConsoleApp/Examples/Structural/DecoratorPattern/DecoratorPatternExampleNoInput.cs)


### Type 2: Execute pattern with input

#### Code

```csharp
// TODO: Code
```
```
// TODO: Output
```

#### Full example

[DecoratorPatternExampleInput](./../../GofConsoleApp/Examples/Structural/DecoratorPattern/DecoratorPatternExampleInput.cs)


## Benefits

- A Decorator provides an enhanced interface to the original object.
- It provides a flexible alternative to subclassing for extending functionality.

## Connection with other patterns

- Adapter provides a different interface to the wrapped object, Proxy provides it with the same interface, and Decorator provides it with an enhanced interface.
- The decorator pattern is structurally nearly identical to the chain of responsibility pattern, the difference being that in a chain of responsibility, exactly one of the classes handles the request, while for the decorator, all classes handle the request.