using GofPatterns.Structural.ProxyPattern;
using NUnit.Framework;

namespace GofPatternsTests.Structural.ProxyPattern;

[TestFixture]
internal class ProxyBoundedAccessTestsWithOutput
{
    [TestCase(new[] { "Hello", "World" }, "Hello", "Hello executed successfully.")]
    [TestCase(new[] { "Hello", "World" }, "World", "World executed successfully.")]
    public void Process_ExecutesIfInputIsFromBoundedInput_ReturnsOutput(string[] boundedInputs, string input,
        string expectedResult)
    {
        // arrange
        var component = new ProxyComponent<string, string>(s => $"{s} executed successfully.");
        var proxy = new ProxyBoundedAccess<string, string>(component, boundedInputs);

        // act
        var sut = proxy.Process(input);

        // assert
        Assert.That(sut, Is.EqualTo(expectedResult));
    }

    [TestCase(new[] { "Hello", "World" }, "Invalid")]
    [TestCase(new[] { "Hello", "World" }, "Out of Bounds")]
    public void Process_IfInputIsNotBounded_ThrowsException(string[] boundedInputs, string input)
    {
        // arrange
        Func<string, string> notExecuted = null!;
        var component = new ProxyComponent<string, string>(notExecuted);

        var sut = new ProxyBoundedAccess<string, string>(component, boundedInputs);

        // act - assert
        Assert.Throws<ArgumentException>(() => sut.Process(input));
    }
}