using GofPatterns.Behavioral.CommandPattern;
using GofPatterns.Behavioral.CommandPattern.Interfaces;
using GofPatterns.Behavioral.CommandPattern.Interfaces.Commands;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.CommandPattern;

[TestFixture]
internal class CommandUndoInvokerTests
{
    [Test]
    public void ExecuteCommands_IfNoWrappers_ReturnsZero()
    {
        // arrange
        var invoker = new CommandUndoInvoker<ICommandUndo<ICommandRequest>,ICommandRequest>();

        // act
        var actualResult = invoker.ExecuteCommands();

        // assert
        Assert.That(actualResult, Is.Zero);
    }
}