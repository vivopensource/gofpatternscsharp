using GofPatterns.Structural.ProxyPattern;
using NUnit.Framework;

namespace GofPatternsTests.Structural.ProxyPattern;

[TestFixture]
internal class ProxyBoundedAccessTests
{
    [TestCase(new[] { "Hello", "World" }, "Hello", "Hello executed successfully.")]
    [TestCase(new[] { "Hello", "World" }, "World", "World executed successfully.")]
    public void Process_ExecutesIfInputIsFromBoundedInput_ReturnsOutput(string[] boundedInputs, string input,
        string expectedResult)
    {
        // arrange
        var testStruct = new TestStruct();
        var function = new Action<string>(s => testStruct.TestValue = $"{s} executed successfully.");

        var component = new ProxyComponent<string>(function);
        var sut = new ProxyBoundedAccess<string>(component, boundedInputs);

        // act
        sut.Process(input);

        // assert
        Assert.That(testStruct.TestValue, Is.EqualTo(expectedResult));
    }

    [TestCase(new[] { "Hello", "World" }, "Invalid")]
    [TestCase(new[] { "Hello", "World" }, "Out of Bounds")]
    public void Process_IfInputIsNotBounded_ThrowsException(string[] boundedInputs, string input)
    {
        // arrange
        Delegate notExecuted = null!;
        var component = new ProxyComponent<string>(notExecuted);

        var proxy = new ProxyBoundedAccess<string>(component, boundedInputs);

        // act - assert
        Assert.Throws<ArgumentException>(() => proxy.Process(input));
    }

    private struct TestStruct
    {
        public string TestValue { get; set; }
    }
}