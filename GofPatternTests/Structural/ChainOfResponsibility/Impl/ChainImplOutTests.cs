using GofPattern.Structural.ChainOfResponsibility;
using GofPattern.Structural.ChainOfResponsibility.Exceptions;
using GofPattern.Structural.ChainOfResponsibility.Impl;
using NUnit.Framework;

namespace GofPatternTests.Structural.ChainOfResponsibility.Impl;

public class ChainImplOutTests
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

        Assert.Throws<MissingResponsibilityInChainException>(() => sut.Execute(string.Empty));
    }

    private static IChain<string, string> GetChain()
    {
        return new ChainImpl<string, string>(v => Foo.Equals(v), Foo + Executed)
            .AddNextInChain(new ChainImpl<string, string>(v => Bar.Equals(v), Bar + Executed))
            .AddNextInChain(new ChainImpl<string, string>(v => FooBar.Equals(v), FooBar + Executed));
    }
}