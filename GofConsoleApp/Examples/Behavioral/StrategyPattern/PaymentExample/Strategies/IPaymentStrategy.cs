using GofPattern.Behavioral.StrategyPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Output;

internal interface IPaymentStrategy : IStrategy<decimal, bool>
{
}