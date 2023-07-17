using System.Reflection;
using Core.Logging;
using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Impl;
using GofPattern.Behavioral.ChainOfResponsibility.Impl.Interfaces;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.ChainOfResponsibility.Impl;

[TestFixture]
internal class ResponsibilityChainInputTests
{
    private const string Foo = "foo";
    private const string Bar = "bar";
    private const string FooBar = "foobar";

    private static ILoggerFactory loggerFactory;
    private static ILogger log;

    [SetUp]
    public void Setup()
    {
        loggerFactory = LogExtensions.GetLoggerFactory();
        log = loggerFactory.CreateLogger<ResponsibilityChainInputTests>();
    }

    [TearDown]
    public void Dispose()
    {
        loggerFactory.Dispose();
    }

    [TestCase(Foo)]
    [TestCase(Bar)]
    [TestCase(FooBar)]
    public void Execute_RunsResponsibilityInChain(string givenValue)
    {
        var action = new Action<string>(WriteText);

        var sut = GetChain(action);

        sut.Execute(givenValue);

        Assert.Pass();
    }

    [Test]
    public void Execute_IfThereIsMissingResponsibilityInChain_ThrowsMissingResponsibilityInChainException()
    {
        var sut = GetChain(null!);

        Assert.Throws<NoResponsibilityException>(() => sut.Execute(string.Empty));
    }

    [TestCase(Foo, typeof(FooException))]
    [TestCase(Bar, typeof(BarException))]
    [TestCase(FooBar, typeof(FooBarException))]
    public void Execute_RunsResponsibilityInChainWithPrecision(string givenValue, Type expectedExceptionType)
    {
        var sut = new ResponsibilityChainInput<string>(v => Foo.Equals(v), ThrowsException)
            .AddNextInChain(new ResponsibilityChainInput<string>(v => Bar.Equals(v), ThrowsException))
            .AddNextInChain(new ResponsibilityChainInput<string>(v => FooBar.Equals(v), ThrowsException));

        var exception = Assert.Throws(typeof(TargetInvocationException), () => sut.Execute(givenValue));

        Assert.That(exception!.InnerException, Is.TypeOf(expectedExceptionType));
    }

    private static IResponsibilityChainInput<string> GetChain(Action<string> action)
    {
        return new ResponsibilityChainInput<string>(v => Foo.Equals(v), action)
            .AddNextInChain(new ResponsibilityChainInput<string>(v => Bar.Equals(v), action))
            .AddNextInChain(new ResponsibilityChainInput<string>(v => FooBar.Equals(v), action));
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

    private static void WriteText(string text) =>
        log.LogInformation(text);

}