using GofPattern.Structural.ChainOfResponsibility.Exceptions;
using GofPattern.Structural.ChainOfResponsibility.NoParams;
using NUnit.Framework;

namespace GofPatternTests.Structural.ChainOfResponsibility.NoParams;

[TestFixture]
internal class ChainTests
{
    [TestCase("foo", "foo executed")]
    [TestCase("bar", "bar executed")]
    [TestCase("foobar", "foobar executed")]
    public void Execute_RunsResponsibilityInChain(string givenValue, string expectedValue)
    {
        var testCls = new TestCls { Value = givenValue };

        GetChain(testCls).Execute();

        Assert.That(testCls.Value, Is.EqualTo(expectedValue));
    }

    [Test]
    public void Execute_IfThereIsMissingResponsibilityInChain_ThrowsMissingResponsibilityInChainException()
    {
        var testCls = new TestCls();

        Assert.Throws<MissingResponsibilityInChainException>(() => GetChain(testCls).Execute());
    }

    private static IChain GetChain(TestCls sutObj)
    {
        return new ChainFoo(sutObj).AddNextInChain(new ChainBar(sutObj)).AddNextInChain(new ChainFooBar(sutObj));
    }

    private class TestCls
    {
        public string Value { get; set; } = string.Empty;
    }

    private class ChainFoo : Chain
    {
        private readonly TestCls _testCls;
        public ChainFoo(TestCls testCls) => _testCls = testCls;
        public override bool IsResponsible() => string.Equals("foo", _testCls.Value);
        protected override void ExecuteResponsibility() => _testCls.Value = "foo executed";
    }

    private class ChainBar : Chain
    {
        private readonly TestCls _testCls;
        public ChainBar(TestCls testCls) => _testCls = testCls;
        public override bool IsResponsible() => string.Equals("bar", _testCls.Value);
        protected override void ExecuteResponsibility() => _testCls.Value = "bar executed";
    }

    private class ChainFooBar : Chain
    {
        private readonly TestCls _testCls;
        public ChainFooBar(TestCls testCls) => _testCls = testCls;
        public override bool IsResponsible() => string.Equals("foobar", _testCls.Value);
        protected override void ExecuteResponsibility() => _testCls.Value = "foobar executed";
    }
}