using GofPatterns.Behavioral.MediatorPattern;

namespace GofConsoleApp.Examples.Behavioral.MediatorPattern;

internal class MediatorPatternExample : AbstractExample
{
    protected override bool Execute()
    {
        var chatRoom = new Mediator<string, string>();
        var person1 = new ChatPerson("Person1", chatRoom, Logger);
        var person2 = new ChatPerson("Person2", chatRoom, Logger);

        chatRoom.Send(person1.Identifier, "Welcome in chatroom!"); // Mediator Calls Colleague (Person1)
        chatRoom.Send("Person2", "Welcome in chatroom!"); // Mediator Calls Colleague (Person2)

        person1.Send(person2.Identifier, $"Hello from {person1.Identifier}"); // Colleague (Person1) Calls Colleague (Person2)
        person2.Send("Person1", $"Hello from {person2.Identifier}"); // Colleague (Person2) Calls Colleague (Person1)

        return true;
    }
}