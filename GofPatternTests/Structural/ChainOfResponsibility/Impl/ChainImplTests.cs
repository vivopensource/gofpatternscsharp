using System.Reflection;
using GofPattern.Structural.ChainOfResponsibility;
using GofPattern.Structural.ChainOfResponsibility.Exceptions;
using GofPattern.Structural.ChainOfResponsibility.Impl;
using NUnit.Framework;
using static System.Console;

namespace GofPatternTests.Structural.ChainOfResponsibility.Impl;

public class ChainImplTests
{
    private const string Foo = "foo";
    private const string Bar = "bar";
    private const string FooBar = "foobar";

    [TestCase(Foo)]
    [TestCase(Bar)]
    [TestCase(FooBar)]
    public void Execute_RunsResponsibilityInChain(string givenValue)
    {
        var action = new Action<string>(WriteLine);

        var sut = GetChain(action);

        sut.Execute(givenValue);

        Assert.Pass();
    }

    [Test]
    public void Execute_IfThereIsMissingResponsibilityInChain_ThrowsMissingResponsibilityInChainException()
    {
        var sut = GetChain(null!);

        Assert.Throws<MissingResponsibilityInChainException>(() => sut.Execute(string.Empty));
    }

    [TestCase(Foo, typeof(FooException))]
    [TestCase(Bar, typeof(BarException))]
    [TestCase(FooBar, typeof(FooBarException))]
    public void Execute_RunsResponsibilityInChainWithPrecision(string givenValue, Type expectedExceptionType)
    {
        var sut = new ChainImpl<string>(v => Foo.Equals(v), ThrowsException)
            .AddNextInChain(new ChainImpl<string>(v => Bar.Equals(v), ThrowsException))
            .AddNextInChain(new ChainImpl<string>(v => FooBar.Equals(v), ThrowsException));

        var exception = Assert.Throws(typeof(TargetInvocationException), () => sut.Execute(givenValue));

        Assert.That(exception!.InnerException, Is.TypeOf(expectedExceptionType));
    }

    private static IChain<string> GetChain(Action<string> action)
    {
        return new ChainImpl<string>(v => Foo.Equals(v), action)
            .AddNextInChain(new ChainImpl<string>(v => Bar.Equals(v), action))
            .AddNextInChain(new ChainImpl<string>(v => FooBar.Equals(v), action));
    }

    private static void ThrowsException(string s)
    {
        switch (s)
        {
            case Foo:
                throw new FooException(s);
            case Bar:
                throw new BarException(s);
            case FooBar:
                throw new FooBarException(s);
        }
    }

    private class FooException : Exception { public FooException(string s) : base(s) { } }
    private class BarException : Exception { public BarException(string s) : base(s) { } }
    private class FooBarException : Exception { public FooBarException(string s) : base(s) { } }
}