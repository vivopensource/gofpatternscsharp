using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility.Impl.Interfaces;

public interface IResponsibilityChainInput<TIn> : IResponsibilityChainInput<IResponsibilityChainInput<TIn>, TIn> { }