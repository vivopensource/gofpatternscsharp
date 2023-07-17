using GofPattern.Behavioral.ChainOfResponsibility;
using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.ChainOfResponsibility;

[TestFixture]
internal class AbstractResponsibilityChainTests
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

        Assert.Throws<NoResponsibilityException>(() => GetChain(testCls).Execute());
    }

    private static IFooBarResponsibilityChain GetChain(TestCls sutObj)
    {
        return new ResponsibilityChainFoo(sutObj).AddNextInChain(new ResponsibilityChainBar(sutObj))
            .AddNextInChain(new ResponsibilityChainFooBar(sutObj));
    }

    private class TestCls
    {
        public string Value { get; set; } = string.Empty;
    }

    private interface IFooBarResponsibilityChain : IResponsibilityChain<IFooBarResponsibilityChain> { }

    private class ResponsibilityChainFoo : AbstractResponsibilityChain<IFooBarResponsibilityChain>, IFooBarResponsibilityChain
    {
        private readonly TestCls _testCls;
        public ResponsibilityChainFoo(TestCls testCls) => _testCls = testCls;
        protected override bool IsResponsible() => string.Equals("foo", _testCls.Value);
        protected override void Process() => _testCls.Value = "foo executed";
    }

    private class ResponsibilityChainBar : AbstractResponsibilityChain<IFooBarResponsibilityChain>, IFooBarResponsibilityChain
    {
        private readonly TestCls _testCls;
        public ResponsibilityChainBar(TestCls testCls) => _testCls = testCls;
        protected override bool IsResponsible() => string.Equals("bar", _testCls.Value);
        protected override void Process() => _testCls.Value = "bar executed";
    }

    private class ResponsibilityChainFooBar : AbstractResponsibilityChain<IFooBarResponsibilityChain>,
        IFooBarResponsibilityChain
    {
        private readonly TestCls _testCls;
        public ResponsibilityChainFooBar(TestCls testCls) => _testCls = testCls;
        protected override bool IsResponsible() => string.Equals("foobar", _testCls.Value);
        protected override void Process() => _testCls.Value = "foobar executed";
    }
}