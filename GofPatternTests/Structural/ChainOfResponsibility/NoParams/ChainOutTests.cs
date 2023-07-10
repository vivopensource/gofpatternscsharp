using GofPattern.Structural.ChainOfResponsibility.Exceptions;
using GofPattern.Structural.ChainOfResponsibility.NoParams;
using NUnit.Framework;

namespace GofPatternTests.Structural.ChainOfResponsibility.NoParams;

[TestFixture]
internal class ChainOutTests
{
    [TestCase("foo", "foo executed")]
    [TestCase("bar", "bar executed")]
    [TestCase("foobar", "foobar executed")]
    public void Execute_RunsResponsibilityInChain(string givenValue, string expectedValue)
    {
        var testCls = new TestCls { Value = givenValue };

        var actualResult = GetChain(testCls).Execute();

        Assert.That(actualResult, Is.EqualTo(expectedValue));
    }

    [Test]
    public void Execute_IfThereIsMissingResponsibilityInChain_ThrowsMissingResponsibilityInChainException()
    {
        var testCls = new TestCls();

        Assert.Throws<MissingResponsibilityInChainException>(() => GetChain(testCls).Execute());
    }

    private static IChain<string> GetChain(TestCls sutObj)
    {
        return new ChainFoo(sutObj).AddNextInChain(new ChainBar(sutObj)).AddNextInChain(new ChainFooBar(sutObj));
    }

    private class TestCls
    {
        public string Value { get; set; } = string.Empty;
    }

    private class ChainFoo : Chain<string>
    {
        private readonly TestCls _testCls;
        public ChainFoo(TestCls testCls) => _testCls = testCls;
        public override bool IsResponsible() => string.Equals("foo", _testCls.Value);
        protected override string ExecuteResponsibility() => "foo executed";
    }

    private class ChainBar : Chain<string>
    {
        private readonly TestCls _testCls;
        public ChainBar(TestCls testCls) => _testCls = testCls;
        public override bool IsResponsible() => string.Equals("bar", _testCls.Value);
        protected override string ExecuteResponsibility() => "bar executed";
    }

    private class ChainFooBar : Chain<string>
    {
        private readonly TestCls _testCls;
        public ChainFooBar(TestCls testCls) => _testCls = testCls;
        public override bool IsResponsible() => string.Equals("foobar", _testCls.Value);
        protected override string ExecuteResponsibility() => "foobar executed";
    }
}