using GofPatterns.Behavioral.StrategyPattern;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.Strategies;

internal interface IPaymentStrategy : IStrategy<decimal, bool> { }