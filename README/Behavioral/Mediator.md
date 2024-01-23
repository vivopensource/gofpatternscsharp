
# Mediator Pattern

- The mediator pattern defines an object that encapsulates how a set of objects interact.
- This pattern is considered to be a behavioral pattern due to the way it can alter the program's running behavior.
- It abstracts how objects cooperate, it manages their interaction. The mediator itself does not have any functionality, it only knows about the colleagues and their interaction.

## Structure

- It consists of mediator, colleague, and client (client does pattern execution).
- Mediator: An abstract mediator class that defines the contract for concrete mediators.
- Colleague: An abstract colleague class that defines the contract for concrete colleagues and also maintains a reference to the mediator.
- Client: A client class that will use the mediator and the colleagues.

## Examples

```csharp
// Mediator colleague
class ChatPerson : MediatorColleague<string, string>
{
    public ChatPerson(string identifier, Mediator<string, string> mediator) : base(identifier, mediator) { }

    public override void Process(string input) => Listening(input);

    private void Listening(string input) => Console.WriteLine($"Listening '{Identifier}': {input}");
}

// Pattern execution
var chatRoom = new Mediator<string, string>();
var person1 = new ChatPerson("Person1", chatRoom);
var person2 = new ChatPerson("Person2", chatRoom);

chatRoom.Send(person1.Identifier, "Welcome in chatroom!"); // Mediator Calls Colleague (Person1)
chatRoom.Send("Person2", "Welcome in chatroom!"); // Mediator Calls Colleague (Person2)

person1.Send(person2.Identifier, $"Hello from {person1.Identifier}"); // Colleague (Person1) Calls Colleague (Person2)
person2.Send("Person1", $"Hello from {person2.Identifier}"); // Colleague (Person2) Calls Colleague (Person1)
```
```
// Output
Listening 'Person1': Welcome in chatroom!
Listening 'Person2': Welcome in chatroom!
Listening 'Person2': Hello from Person1
Listening 'Person1': Hello from Person2
```

#### Full example

[MediatorPatternExample](./../../GofConsoleApp/Examples/Behavioral/MediatorPattern/MediatorPatternExample.cs)

### Classes and interfaces used in example:

- [IMediator](./../../GofPatterns/Behavioral/MediatorPattern/IMediator.cs) - interface for mediators
- [Mediator](./../../GofPatterns/Behavioral/MediatorPattern/Mediator.cs) - class for mediators
- [IMediatorColleague](./../../GofPatterns/Behavioral/MediatorPattern/IMediatorColleague.cs) - interface for colleagues
- [MediatorColleague](./../../GofPatterns/Behavioral/MediatorPattern/MediatorColleague.cs) - abstract class for colleagues

## Benefits

- Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
- It limits subclassing. A mediator localizes behavior that otherwise would be distributed among several objects. Changing this behavior requires subclassing Mediator only; Colleague classes can be reused as is.
- It simplifies object protocols. A mediator replaces many-to-many interactions with one-to-many interactions between the mediator and its colleagues. One-to-many relationships are easier to understand, maintain, and extend.


## Similarity with other patterns

- The mediator pattern is similar to the facade pattern in that it abstracts functionality of existing classes. The mediator is similar to the facade in that it abstracts functionality of existing classes. The mediator abstracts/centralizes arbitrary communication between colleague objects, it routinely "adds value", and it is known/referenced by the colleague objects (i.e., it defines a multidirectional protocol). In contrast, the facade only defines a simpler interface to a subsystem, it doesn't add new functionality, and it is not known by the subsystem classes (i.e., it defines a unidirectional protocol where it makes requests of the subsystem classes but not vice versa).
- The mediator pattern is similar to the observer pattern in that it abstracts the notion of "independent change" (or "change in state") and the propagation of that change (also known as notifications). The mediator abstracts/centralizes arbitrary communication between colleague objects, whereas the observer pattern focuses on blind communication via observable/observer interfaces. In addition, the mediator manages the state of its colleagues, whereas the observer pattern does not.
- The mediator pattern is similar to the controller pattern and similar to the hub pattern in that all three manage communication between known participants (colleagues, clients, subscribers). In the controller pattern, the controller is a known intermediary. In the hub pattern, the hub is a known intermediary. In the mediator pattern, the mediator is a neutral intermediary.