using Core.Console;
using Core.Extensions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using GofPatternsTests.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums.ChainOrchestratorHandleOptions;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofPatternsTests.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex;

[TestFixture]
internal class ResponsibilityChainOrchestratorTests
{
    private const string Foo = "foo";
    private const string Bar = "bar";
    private const string FooBar = "foobar";

    [SetUp]
    public void Setup()
    {
        _loggerFactory = ConsoleExtensions.GetLoggerFactory();
        _log = _loggerFactory.CreateLogger<ResponsibilityChainOrchestratorTests>();
    }

    [TearDown]
    public void Dispose()
    {
        _loggerFactory.Dispose();
    }

    [Test]
    public void Execute_AlwaysHandleResponsibility_WithHandleAlways()
    {
        // arrange
        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain(executeFunction);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>()
            .Append(responsibilityFoo, HandleAlways, InvokeNextAlways)
            .Append(responsibilityBar, HandleWhenResponsible, InvokeNextWhenNotResponsible)
            .Append(responsibilityFooBar, HandleWhenResponsible, InvokeNextWhenNotResponsible);

        // act
        chainOrchestrator.Execute("bar");

        // assert
        mockLogger.Verify(ms => ms.Log(It.IsAny<string>()), Times.Exactly(2));
    }

    [Test]
    public void Execute_NeverInvokesNextResponsibility_DoesNotInvokeNext()
    {
        // arrange
        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        var responsibilityFoo = GetChain(executeFunction).Item1;

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>()
            .Append(responsibilityFoo, HandleAlways, InvokeNextNever);

        // act
        chainOrchestrator.Execute("bar");

        // assert
        mockLogger.Verify(ms => ms.Log(It.IsAny<string>()), Times.Exactly(1));
    }

    [Test]
    public void Execute_ChainName()
    {
        // arrange
        const string expectedName = "FooCoR";

        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        bool IsResponsibleFoo(string v) => Foo.Contains(v);
        var responsibilityFoo = new Responsibility<string>(IsResponsibleFoo, executeFunction);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>()
            .Append(responsibilityFoo, HandleWhenResponsible, InvokeNextWhenNotResponsible, expectedName);

        // act
        chainOrchestrator.Execute("foo");

        // assert
        Assert.That(chainOrchestrator.Chain!.Name, Is.EqualTo(expectedName));
        Assert.That(chainOrchestrator.CurrentChain!.Name, Is.EqualTo(expectedName));
    }

    [TestCase(Foo)]
    [TestCase(Bar)]
    [TestCase(FooBar)]
    public void
        Execute_InvokesNextResponsibilityIfNotResponsible_WithHandleWhenResponsibleAndInvokeNextWhenNotResponsible(
            string givenValue)
    {
        // arrange
        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain(executeFunction);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>()
            .Append(responsibilityFoo, HandleWhenResponsible, InvokeNextWhenNotResponsible)
            .Append(responsibilityBar, HandleWhenResponsible, InvokeNextWhenNotResponsible)
            .Append(responsibilityFooBar, HandleWhenResponsible, InvokeNextNever);

        // act
        chainOrchestrator.Execute(givenValue);

        // assert
        mockLogger.Verify(ms => ms.Log(It.IsAny<string>()), Times.Exactly(1));
    }

    [Test]
    public void Execute_InvokesNextResponsibilityIfResponsible_WithHandleWhenResponsibleAndInvokeNextWhenResponsible()
    {
        // arrange
        const string expectedName = "FooBarCoR";
        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain(executeFunction);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>(expectedName)
            .Append(responsibilityFoo, HandleWhenResponsible, InvokeNextWhenNotResponsible)
            .Append(responsibilityBar, HandleWhenResponsible, InvokeNextWhenResponsible)
            .Append(responsibilityFooBar, HandleWhenResponsible, InvokeNextNever);

        // act
        chainOrchestrator.Execute("bar");

        // assert
        Assert.That(chainOrchestrator.Name, Is.EqualTo(expectedName));
        mockLogger.Verify(ms => ms.Log(It.IsAny<string>()), Times.Exactly(2));
    }

    [Test]
    public void Execute_IfThereIsMissingResponsibilityInChain_ThrowsMissingResponsibilityInChainException()
    {
        // arrange
        var fooHandler = GetChain(Console.WriteLine).Item1;

        var sut = new ResponsibilityChainOrchestrator<string>()
            .Append(fooHandler, HandleAlways, InvokeNextAlways);

        // act - assert
        Assert.Throws<MissingResponsibilityException>(() => sut.Execute(string.Empty));
    }

    private static Tuple<Responsibility<string>, Responsibility<string>, Responsibility<string>> GetChain(
        Action<string> executeFunction)
    {
        var responsibilityFoo = new Responsibility<string>(v => Foo.Contains(v), executeFunction);

        var responsibilityBar = new Responsibility<string>(v => Bar.Contains(v), executeFunction);

        var responsibilityFooBar = new Responsibility<string>(v => FooBar.Contains(v), executeFunction);

        return new Tuple<Responsibility<string>, Responsibility<string>, Responsibility<string>>(responsibilityFoo,
            responsibilityBar, responsibilityFooBar);
    }

    private static ILoggerFactory _loggerFactory = ConsoleExtensions.GetLoggerFactory();
    private static ILogger _log = _loggerFactory.CreateLogger<ResponsibilityChainOrchestratorInputTests>();
}