using GofConsoleApp.Examples.Creational.BuilderPattern;
using GofPatterns.Creational.BuilderPattern;
using NUnit.Framework;

namespace GofPatternsTests.Creational.BuilderPattern;

[TestFixture]
internal class BuilderTests
{
    [Test]
    public void Append_WhenCalled_AppendsInput()
    {
        // arrange
        IBuilder<decimal> sut = new AdditionBuilder();

        // act
        sut.Append(2);
        var actualResult = sut.Output();

        // assert
        Assert.That(actualResult, Is.EqualTo(2));
    }

    
    [Test]
    public void Output_WhenCalled_ReturnsOutput()
    {
        // arrange
        var sut = new AdditionBuilder(1);

        // act
        sut.Append(2).Append(4).Append(6);
        var actualResult = sut.Output();

        // assert
        Assert.That(actualResult, Is.EqualTo(13.0m));
    }
}