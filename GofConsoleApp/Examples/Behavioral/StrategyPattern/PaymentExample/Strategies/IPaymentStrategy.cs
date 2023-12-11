using GofPattern.Behavioral.StrategyPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentExample.Strategies;

internal interface IPaymentStrategy : IStrategy<decimal, bool> { }