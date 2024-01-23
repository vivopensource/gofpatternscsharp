
# Strategy Pattern

- The strategy pattern is a behavioral design pattern that enables selecting an algorithm at runtime.
- Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.
- Strategy lets the algorithm vary independently from clients that use it.

## Structure
- It consists of context and strategy.
- Context: A context class that will contain the strategy object.
- Strategy: A strategy class that will contain the action to be performed.

## Examples

### Type 1: Execute pattern without return value

#### Code

```csharp
// Create Context
class SenderStrategyContext : IStrategyContext<string>
{
    public void SetStrategy(IStrategy<string> strategy) => Strategy = strategy;

    public void ExecuteStrategy(string input) => Strategy!.Execute(input);

    public IStrategy<string>? Strategy { get; set; }
}

// Create Strategies
class EmailStrategy : IStrategy<string>
{
    public void Execute(string input) => Console.WriteLine($"Sending {Name}: {input}");

    public string Name => "Email";
}
class LetterStrategy : IStrategy<string>
{
    public void Execute(string input) => Console.WriteLine($"Sending {Name}: {input}");

    public string Name => "Letter";
}

// Pattern execution
var senderContext = new SenderStrategyContext();
var email = new EmailStrategy();
var letter = new LetterStrategy();

senderContext.SetStrategy(email);
senderContext.ExecuteStrategy("Hello World!");

senderContext.SetStrategy(letter);
senderContext.ExecuteStrategy("Hello World!");
```
```
// Output
Sending Email: Hello World!
Sending Letter: Hello World!
```

#### Full example

[StrategyPatternSenderExample](./../../GofConsoleApp/Examples/Behavioral/StrategyPattern/StrategyPatternSenderExample.cs)


### Type 2: Execute pattern and expect return value

#### Code
    
```csharp
// Create Context
class PaymentStrategyContext : IStrategyContext<decimal, bool>
{
    public void SetStrategy(IStrategy<decimal, bool> strategy) => Strategy = strategy;

    public bool ExecuteStrategy(decimal input)
    {
        var name = Strategy!.Name;
        Console.WriteLine($"Payment using '{name}': {input} euro");
        return Strategy!.Execute(input);
    }

    public IStrategy<decimal, bool>? Strategy { get; private set; }
}

// Create Strategies
class CreditCardPaymentStrategy : IStrategy<decimal, bool>
{
    private decimal limit;

    public CreditCardPaymentStrategy(decimal limit) => this.limit = limit;

    public bool Execute(decimal input)
    {
        if (limit - input < 0)
            return false;

        limit -= input;
        return true;
    }

    public string Name => "Credit Card";
}
class DebitCardPaymentStrategy : IStrategy<decimal, bool>
{
    private decimal balance;

    public DebitCardPaymentStrategy(decimal balance) => this.balance = balance;

    public bool Execute(decimal input)
    {
        if (balance - input < 0)
            return false;

        balance -= input;
        return true;
    }

    public string Name => "Debit Card";
}

// Pattern execution
IStrategyContext<decimal, bool> paymentContext = new PaymentStrategyContext();
var creditCard = new CreditCardPaymentStrategy(1000);
var debitCard = new DebitCardPaymentStrategy(1000);

paymentContext.SetStrategy(creditCard);
bool output = paymentContext.ExecuteStrategy(100);
Console.WriteLine(output ? "Payment successful." : "Payment unsuccessful.");

paymentContext.SetStrategy(debitCard);
output = paymentContext.ExecuteStrategy(200);
Console.WriteLine(output ? "Payment successful." : "Payment unsuccessful.");

paymentContext.SetStrategy(debitCard);
output = paymentContext.ExecuteStrategy(900);
Console.WriteLine(output ? "Payment successful." : "Payment unsuccessful.");

paymentContext.SetStrategy(creditCard);
output = paymentContext.ExecuteStrategy(900);
Console.WriteLine(output ? "Payment successful." : "Payment unsuccessful.");
```
```
// Output
Payment using 'Credit Card': 100 euro
Payment successful.
Payment using 'Debit Card': 200 euro
Payment successful.
Payment using 'Debit Card': 900 euro
Payment unsuccessful.
Payment using 'Credit Card': 900 euro
Payment successful.
```

#### Full example

[StrategyPatternPaymentExample](./../../GofConsoleApp/Examples/Behavioral/StrategyPattern/StrategyPatternPaymentExample.cs)

### Classes and interfaces used in example:
- [IStrategy](./../../GofPatterns/Behavioral/StrategyPattern/IStrategy.cs) - interface for strategies
- [IStrategyContext](./../../GofPatterns/Behavioral/StrategyPattern/IStrategyContext.cs) - interface for strategy context
- [StrategyContext](./../../GofPatterns/Behavioral/StrategyPattern/StrategyContext.cs) - class for strategy context

## Benefits
- Strategy is one of the patterns included in the influential book Design Patterns by Gamma et al. that popularized the concept of using design patterns to describe how to design flexible and reusable object-oriented software.
- The strategy pattern is intended to provide a means to define a family of algorithms, encapsulate each one as an object, and make them interchangeable.
- Strategy is often used to implement the various algorithms (sometimes called "strategies") for a particular operation (for example, searching a file, or sorting a collection).

## Similarity with other patterns
- Many patterns can be considered as a particular implementation of the strategy pattern.
- The strategy pattern is a particularly straightforward example of dependency injection.
- The strategy pattern is also known as the policy pattern. It is a particular implementation of the more general handle/body idiom.
- The strategy pattern is analogous to the strategy pattern in architecture.