# Observer Pattern

- The observer pattern is a software design pattern in which an object, called the subject, maintains a list of its dependents, called observers, and notifies them automatically of any state changes, usually by calling one of their methods.
- The observer pattern is a design pattern that allows a subject to publish changes to its state. Other objects subscribe to be immediately notified of any changes.
- The observer pattern is mostly used to implement distributed event handling systems, in "event driven" software. Most modern languages such as C# have built in "event" constructs which implement the observer pattern components.

## Structure

- It consists of subject, observer, and client (client does pattern execution).
- Subject: An object that maintains a list of its dependents, called observers, and notifies them automatically of any state changes, usually by calling one of their methods.
- Observer: An interface that defines the method to be called when a subject is updated.
- Client: A client class that will use the subject and observer objects.

## Example

### Components

```csharp
// Subscribers
private class PersonJohnDoe : ISubscriber<string>
{
    public void Update(string input) => Console.WriteLine($"John Doe received: {input}");
}

private class PersonAndrewSmith : ISubscriber<string>
{
    public void Update(string input) => Console.WriteLine($"Andrew Smith received: {input}");
}
```

### Type 1: Execute pattern with simple implementation

```csharp
var johnDoe = new PersonJohnDoe();
var andrewSmith = new PersonAndrewSmith();

IPublisher<string> newPublisher = new Publisher<string>();

newPublisher.AddSubscriber(johnDoe);
newPublisher.AddSubscriber(andrewSmith);

newPublisher.NotifySubscribers("Hello Subscribers!");
newPublisher.NotifySubscribers("How are you doing?");
```
```
// Output:
John Doe received: Hello Subscribers!
Andrew Smith received: Hello Subscribers!
John Doe received: How are you doing?
Andrew Smith received: How are you doing?
```

#### Full example

[ObserverPatternExample](./../../GofConsoleApp/Examples/Behavioral/ObserverPattern/ObserverPatternExample.cs)


### Type 2: Execute pattern with category implementation

```csharp
enum EnumTopic { Sports, Politics, Weather, Holidays }

// Observer - Pattern execution
var johnDoe = new PersonJohnDoe();
var andrewSmith = new PersonAndrewSmith();

IPublisher<string, EnumTopic> newPublisher = new Publisher<string, EnumTopic>();

newPublisher.AddSubscriber(johnDoe, Sports);
newPublisher.AddSubscriber(andrewSmith, Sports);
newPublisher.AddSubscriber(johnDoe, Politics);
newPublisher.AddSubscriber(andrewSmith, Weather);
newPublisher.AddSubscriber(johnDoe, Holidays);

newPublisher.NotifySubscribers("Germany won Fifa world cup.", Sports);
newPublisher.NotifySubscribers("Election campaign started by the candidates.", Politics);
newPublisher.NotifySubscribers("Heavy snow fall expected in upcoming week.", Weather);
newPublisher.NotifySubscribers("Holiday season experience flight booking at all time high.", Holidays);
```

```
// Output:
John Doe received: Germany won Fifa world cup.
Andrew Smith received: Germany won Fifa world cup.
John Doe received: Election campaign started by the candidates.
Andrew Smith received: Heavy snow fall expected in upcoming week.
John Doe received: Holiday season experience flight booking at all time high.
```

#### Full example

[ObserverPatternExampleWithCategory](./../../GofConsoleApp/Examples/Behavioral/ObserverPattern/ObserverPatternExampleWithCategory.cs)

### Classes and interfaces used in example:
- [ISubscriber](./../../GofPatterns/Behavioral/ObserverPattern/Interfaces/ISubscriber.cs) - interface for subscribers
- [IPublisher](./../../GofPatterns/Behavioral/ObserverPattern/Interfaces/IPublisher.cs) - interface for publishers
- [Publisher](./../../GofPatterns/Behavioral/ObserverPattern/Publisher.cs) - class for publishers


## Benefits

- It describes the coupling between the objects and the observer.
- It provides the support for broadcast-type communication.
- It is easy to implement, change and reuse.

## Similarity with other patterns

- The observer pattern is also a key part in the familiar model–view–controller (MVC) architectural pattern. The observer pattern is implemented in numerous programming libraries and systems, including almost all GUI toolkits.

## Drawbacks

- The observer pattern can cause memory leaks, known as the lapsed listener problem, because in basic implementation it requires both explicit registration and explicit deregistration, as in the dispose pattern, because the subject holds strong references to the observers, keeping them alive. This can be prevented by the subject holding weak references to the observers.