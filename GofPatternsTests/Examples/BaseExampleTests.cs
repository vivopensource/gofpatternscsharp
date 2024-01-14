using GofConsoleApp.Examples;
using NUnit.Framework;

namespace GofPatternsTests.Examples;

[TestFixture]
internal class BaseExampleTests : BaseTest
{
    [Test]
    public void AcceptInputDecimal_WithValidInput_ReturnsTrue()
    {
        // arrange
        const string input = "1.1";
        MockInputReader.Setup(x => x.AcceptInput()).Returns(input);

        // act
        var actualResult = new TestExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void AcceptInputDecimal_WithInValidInput_ThrowsException()
    {
        // arrange
        const string input = "abc";
        MockInputReader.Setup(x => x.AcceptInput()).Returns(input);

        // act - assert
        Assert.Throws<FormatException>(() =>
            new TestExample().Execute(MockConsoleLogger.Object, MockInputReader.Object));
    }

    private class TestExample : BaseExample
    {
        protected override bool Execute()
        {
            AcceptInputDecimal("Enter a decimal:");
            return true;
        }
    }
}