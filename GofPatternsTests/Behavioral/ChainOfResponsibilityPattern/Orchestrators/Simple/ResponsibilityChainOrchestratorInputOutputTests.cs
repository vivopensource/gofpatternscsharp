using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;

[TestFixture]
internal class ResponsibilityChainOrchestratorInputOutputTests
{
    private const string Foo = "foo";
    private const string Bar = "bar";
    private const string FooBar = "foobar";
    private const string Handled = "-Handled";

    [TestCase(Foo)]
    [TestCase(Bar)]
    [TestCase(FooBar)]
    public void Execute_IdentifiesAppropriateResponsibilityAndInvokesResponsibility(string givenValue)
    {
        // arrange
        const string expectedName = "FooBarCoR";

        var responsibilityFoo = new Responsibility<string, string>(v => Foo.Equals(v), input => input + Handled);

        var responsibilityBar = new Responsibility<string, string>(v => Bar.Equals(v), AppendHandled);

        var responsibilityFooBar = new Responsibility<string, string>(v => FooBar.Equals(v), input => input + Handled);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string, string>(expectedName)
            .Append(responsibilityFoo, $"{Foo} Chain")
            .Append(responsibilityBar, $"{Bar} Chain")
            .Append(responsibilityFooBar, $"{FooBar} Chain");

        // act
        var actualResult = chainOrchestrator.Execute(givenValue);

        // assert
        Assert.That(actualResult, Is.EqualTo(givenValue + Handled));
        Assert.That(chainOrchestrator.Name, Is.EqualTo(expectedName));
        Assert.That(chainOrchestrator.CurrentChain!.Name, Is.EqualTo($"{givenValue} Chain"));
    }

    [Test]
    public void Execute_IfNoAppropriateResponsibility_ThrowsException()
    {
        // arrange
        Func<string, string> notExecuted = null!;
        var responsibilityFoo = new Responsibility<string, string>(v => Foo.Equals(v), notExecuted);
        var responsibilityBar = new Responsibility<string, string>(v => Bar.Equals(v), AppendHandled);
        var responsibilityFooBar = new Responsibility<string, string>(v => FooBar.Equals(v), notExecuted);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string, string>()
            .Append(responsibilityFoo)
            .Append(responsibilityBar)
            .Append(responsibilityFooBar);

        // act - assert
        Assert.Throws<MissingResponsibilityException>(() => chainOrchestrator.Execute("Not Foo, Bar or FooBar"));
    }

    private static string AppendHandled(string input)
    {
        return input + Handled;
    }
}