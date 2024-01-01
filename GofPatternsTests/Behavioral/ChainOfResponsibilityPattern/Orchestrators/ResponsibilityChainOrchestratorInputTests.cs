using Core.Console;
using Core.Extensions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

[TestFixture]
internal class ResponsibilityChainOrchestratorInputTests
{
    private const string Foo = "foo";
    private const string Bar = "bar";
    private const string FooBar = "foobar";

    [SetUp]
    public void Setup()
    {
        _loggerFactory = ConsoleExtensions.GetLoggerFactory();
        _log = _loggerFactory.CreateLogger<ResponsibilityChainOrchestratorInputTests>();
    }

    [TearDown]
    public void Dispose()
    {
        _loggerFactory.Dispose();
    }

    [TestCase(Foo)]
    [TestCase(Bar)]
    [TestCase(FooBar)]
    public void Execute_InvokesNextResponsibilityIfNotResponsible(string givenValue)
    {
        // arrange
        const string expectedName = "FooBarCoR";

        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain(executeFunction);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>(expectedName)
            .Append(responsibilityFoo).Append(responsibilityBar).Append(responsibilityFooBar);

        // act
        chainOrchestrator.Execute(givenValue);

        // assert
        Assert.That(chainOrchestrator.Name, Is.EqualTo(expectedName));
        mockLogger.Verify(ms => ms.Log(It.IsAny<string>()), Times.Exactly(1));
    }

    [Test]
    public void Execute_InvokesNextResponsibilityIfResponsible()
    {
        // arrange
        const int expectedNumberOfLogs = 1;
        var mockLogger = new Mock<ConsoleLogger>(_log);
        var mockLoggerObject = mockLogger.Object;

        var executeFunction = new Action<string>(mockLoggerObject.Log);

        var (responsibilityFoo, responsibilityBar, responsibilityFooBar) = GetChain(executeFunction);

        var chainOrchestrator = new ResponsibilityChainOrchestrator<string>()
            .Append(responsibilityFoo).Append(responsibilityBar).Append(responsibilityFooBar);

        // act
        chainOrchestrator.Execute("bar");

        // assert
        mockLogger.Verify(ms => ms.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
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