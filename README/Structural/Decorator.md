
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
interface INotifier : IDecorator<INotifier> { }

class EmailNotifier : INotifier
{
    public void Execute() => Console.WriteLine("Email-Notifier executed.");
}

// Decotator using Interface
class SmsNotifier : INotifier
{
    private readonly INotifier notifier;

    public SmsNotifier(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public void Execute()
    {
        notifier.Execute();
        Console.WriteLine("Sms-Notifier executed.");
    }
}

// Decotator using Concrete Class
class LetterNotifier : Decorator<INotifier>, INotifier
{
    public LetterNotifier(INotifier notifier) : base(notifier) { }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine("Letter-Notifier executed.");
    }
}

// Pattern execution
new LetterNotifier(new SmsNotifier(new EmailNotifier())).Execute()
```
```
// Output
Email-Notifier executed.
Sms-Notifier executed.
Letter-Notifier executed.
```

#### Full example

[DecoratorPatternExampleNoInput](./../../GofConsoleApp/Examples/Structural/DecoratorPattern/DecoratorPatternExampleNoInput.cs)


### Type 2: Execute pattern with input

#### Code

```csharp
interface INotifier : IDecorator<INotifier, string> { }

class EmailNotifier : INotifier
{
    public void Execute(string input) => Console.WriteLine($"Email sent: {input}");
}

// Decotator implementation using Decotator Interface
class SmsNotifier : INotifier
{
    private readonly INotifier notifier;

    public SmsNotifier(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public void Execute(string input)
    {
        notifier.Execute(input);
        Console.WriteLine($"Sms sent: {input}");
    }
}

// Decotator implementation using Decotator Concrete Class
class LetterNotifier : Decorator<INotifier, string>, INotifier
{
    public LetterNotifier(INotifier notifier) : base(notifier) { }

    public void Execute(string input)
    {
        base.Execute(input);
        Console.WriteLine($"Letter sent: {input}");
    }
}

// Pattern execution
new LetterNotifier(new SmsNotifier(new EmailNotifier())).Execute("Hello World!")
```
```
// Output
Email sent: Hello World!
Sms sent: Hello World!
Letter sent: Hello World!
```

#### Full example

[DecoratorPatternExampleInput](./../../GofConsoleApp/Examples/Structural/DecoratorPattern/DecoratorPatternExampleInput.cs)


## Benefits

- A Decorator provides an enhanced interface to the original object.
- It provides a flexible alternative to subclassing for extending functionality.

## Similarity with other patterns

- Adapter provides a different interface to the wrapped object, Proxy provides it with the same interface, and Decorator provides it with an enhanced interface.
- The decorator pattern is structurally nearly identical to the chain of responsibility pattern, the difference being that in a chain of responsibility, exactly one of the classes handles the request, while for the decorator, all classes handle the request.