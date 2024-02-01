using GofPatterns.Behavioral.CommandPattern;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.CommandPattern;

[TestFixture]
internal class CommandInvokerUndoTests
{
    [Test]
    public void ExecuteCommands_IfNoWrappers_ReturnsZero()
    {
        // arrange
        var invoker = new CommandInvokerUndo<ICommandUndo<ICommandRequest>,ICommandRequest>();

        // act
        var actualResult = invoker.ExecuteCommands();

        // assert
        Assert.That(actualResult, Is.Zero);
    }
}