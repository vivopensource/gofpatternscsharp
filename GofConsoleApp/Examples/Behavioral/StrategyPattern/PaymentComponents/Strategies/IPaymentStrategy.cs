using GofPatterns.Behavioral.StrategyPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.Strategies;

internal interface IPaymentStrategy : IStrategy<decimal, bool> { }