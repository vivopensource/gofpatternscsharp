using GofPattern.Behavioral.ChainOfResponsibility;
using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.ChainOfResponsibility;

[TestFixture]
internal class AbstractResponsibilityChainOutputTests
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

        Assert.Throws<NoResponsibilityException>(() => GetChain(testCls).Execute());
    }

    private static IFooBarResponsibilityChainOutput GetChain(TestCls sutObj)
    {
        return new ResponsibilityChainOutputFoo(sutObj).AddNextInChain(new ResponsibilityChainOutputBar(sutObj))
            .AddNextInChain(new ResponsibilityChainOutputFooBar(sutObj));
    }

    private class TestCls
    {
        public string Value { get; set; } = string.Empty;
    }

    private interface IFooBarResponsibilityChainOutput : IResponsibilityChainOutput<IFooBarResponsibilityChainOutput, string> { }

    private class ResponsibilityChainOutputFoo : ResponsibilityChainOutput<IFooBarResponsibilityChainOutput, string>,
        IFooBarResponsibilityChainOutput
    {
        private readonly TestCls _testCls;
        public ResponsibilityChainOutputFoo(TestCls testCls) => _testCls = testCls;
        protected override bool IsResponsible() => string.Equals("foo", _testCls.Value);
        protected override string Process() => "foo executed";
    }

    private class ResponsibilityChainOutputBar : ResponsibilityChainOutput<IFooBarResponsibilityChainOutput, string>,
        IFooBarResponsibilityChainOutput
    {
        private readonly TestCls _testCls;
        public ResponsibilityChainOutputBar(TestCls testCls) => _testCls = testCls;
        protected override bool IsResponsible() => string.Equals("bar", _testCls.Value);
        protected override string Process() => "bar executed";
    }

    private class ResponsibilityChainOutputFooBar : ResponsibilityChainOutput<IFooBarResponsibilityChainOutput, string>,
        IFooBarResponsibilityChainOutput
    {
        private readonly TestCls _testCls;
        public ResponsibilityChainOutputFooBar(TestCls testCls) => _testCls = testCls;
        protected override bool IsResponsible() => string.Equals("foobar", _testCls.Value);
        protected override string Process() => "foobar executed";
    }
}