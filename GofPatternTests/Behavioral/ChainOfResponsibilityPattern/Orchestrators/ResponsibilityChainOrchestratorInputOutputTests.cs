using GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

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
    public void
        Execute_InvokesNextResponsibilityIfNotResponsible_WithHandleWhenResponsibleAndInvokeNextWhenNotResponsible(
            string givenValue)
    {
        // arrange

        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain();

        var chain = new ResponsibilityChainOrchestrator<IResponsibility<string, string>, string, string>()
            .Append(responsibilityFoo).Append(responsibilityBar).Append(responsibilityFooBar);

        // act
        var actualResult = chain.Execute(givenValue);

        // assert
        Assert.That(actualResult, Is.EqualTo(givenValue + Handled));
    }

    [Test]
    public void Execute_IfOutputIsNull_ThrowsException()
    {
        // arrange
        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain();

        var chain = new ResponsibilityChainOrchestrator<IResponsibility<string, string>, string, string>()
            .Append(responsibilityFoo).Append(responsibilityBar).Append(responsibilityFooBar);

        // act - assert
        Assert.Throws<MissingResponsibilityException>(() => chain.Execute(string.Empty));

    }

    private static (Responsibility<string, string> responsibilityFoo, Responsibility<string, string> responsibilityBar,
        Responsibility<string, string> responsibilityFooBar) GetChain()
    {
        var responsibilityFoo = new Responsibility<string, string>(v => Foo.Equals(v), Foo + Handled);

        var responsibilityBar = new Responsibility<string, string>(v => Bar.Equals(v), AppendHandled);

        var responsibilityFooBar = new Responsibility<string, string>(v => FooBar.Equals(v), FooBar + Handled);

        return (responsibilityFoo, responsibilityBar, responsibilityFooBar);
    }

    private static string AppendHandled(string input)
    {
        return input + Handled;
    }
}