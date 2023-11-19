using GofPattern.Behavioral.StrategyPattern;
using GofPattern.Behavioral.StrategyPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.StrategyContexts;

internal class PaymentContext
{
    private IStrategyContext<decimal, bool> strategyContext = new StrategyContext<decimal, bool>();
    
    public decimal MaximumAmount { get; set; } = 0;
}