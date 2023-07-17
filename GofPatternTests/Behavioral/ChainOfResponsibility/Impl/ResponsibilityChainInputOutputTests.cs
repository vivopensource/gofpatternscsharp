using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Impl;
using GofPattern.Behavioral.ChainOfResponsibility.Impl.Interfaces;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.ChainOfResponsibility.Impl;

[TestFixture]
internal class ResponsibilityChainInputOutputTests
{
    private const string Foo = "foo";
    private const string Bar = "bar";
    private const string FooBar = "foobar";
    private const string Executed = "-executed";

    [TestCase(Foo)]
    [TestCase(Bar)]
    [TestCase(FooBar)]
    public void Execute_RunsResponsibilityInChain(string givenValue)
    {
        var expectedValue = givenValue + Executed;

        var sut = GetChain();

        var actualResult = sut.Execute(givenValue);

        Assert.That(actualResult, Is.EqualTo(expectedValue));
    }

    [Test]
    public void Execute_IfThereIsMissingResponsibilityInChain_ThrowsMissingResponsibilityInChainException()
    {
        var sut = GetChain();

        Assert.Throws<NoResponsibilityException>(() => sut.Execute(string.Empty));
    }

    private static IResponsibilityChainInputOutput<string, string> GetChain()
    {
        return new ResponsibilityChainInputOutput<string, string>(v => Foo.Equals(v), Foo + Executed)
            .AddNextInChain(new ResponsibilityChainInputOutput<string, string>(v => Bar.Equals(v), Bar + Executed))
            .AddNextInChain(
                new ResponsibilityChainInputOutput<string, string>(v => FooBar.Equals(v), FooBar + Executed));
    }
}