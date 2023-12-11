using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using GofConsoleApp.Examples.Behavioral.CommandPattern;
using GofConsoleApp.Examples.Behavioral.StatePattern;
using GofConsoleApp.Examples.Behavioral.StrategyPattern;
using GofConsoleApp.Examples.Structural.DecoratorPattern;
using GofConsoleApp.Examples.Structural.ProxyPattern;

namespace GofConsoleApp.Examples.ExecutionHelpers;

// ReSharper disable MemberCanBePrivate.Global
internal static class PatternOptions
{
    internal const string DecoratorPatternOption = "11";
    internal const string DecoratorPatternOption2 = "11.2";
    internal const string ProxyPatternOption = "12";
    internal const string ProxyPatternOptionBoundedInput = "12.2";
    internal const string ProxyPatternOptionBoundedInputOutput = "12.3";
    internal const string ChainOfResponsibilityPatternOption = "21";
    internal const string ChainOfResponsibilityPatternOption2 = "21.2";
    internal const string CommandPatternOption = "22";
    internal const string CommandPatternUndoOption = "22.2";
    internal const string LightPatternOptionBulbExample = "23";
    internal const string StrategyPatternOptionSender = "24";
    internal const string StrategyPatternOptionPayment = "24.2";

    internal static readonly IDictionary<string, PatternExampleMap> Patterns = new Dictionary<string, PatternExampleMap>
    {
        // Structural Patterns
        {
            DecoratorPatternOption,
            new PatternExampleMap("Decorator Pattern >> Input",
                new DecoratorPatternExampleInput())
        },
        {
            DecoratorPatternOption2,
            new PatternExampleMap("Decorator Pattern >> No Input", new DecoratorPatternExampleNoInput())
        },
        {
            ProxyPatternOption,
            new PatternExampleMap("Proxy Pattern >> Cached Output", new ProxyPatternConfigProviderExampleCachedOutput())
        },
        {
            ProxyPatternOptionBoundedInput,
            new PatternExampleMap("Proxy Pattern >> Bounded Input", new ProxyPatternNewsChannelExampleBoundedInput())
        },
        {
            ProxyPatternOptionBoundedInputOutput,
            new PatternExampleMap("Proxy Pattern >> Bounded Input with Output",
                new ProxyPatternUserInterfaceExampleBoundedInput())
        },

        // Behavioral Patterns
        {
            ChainOfResponsibilityPatternOption,
            new PatternExampleMap("Chain Of Responsibility Pattern >> Input",
                new ChainOfResponsibilityPatternExampleInput())
        },
        {
            ChainOfResponsibilityPatternOption2,
            new PatternExampleMap("Chain Of Responsibility Pattern >> Input & Output",
                new ChainOfResponsibilityPatternExampleInputWithOutput())
        },
        {
            CommandPatternOption,
            new PatternExampleMap("Command Pattern", new CommandPatternRestaurantExample())
        },
        {
            CommandPatternUndoOption,
            new PatternExampleMap("Command Pattern >> Undo Example", new CommandPatternUndoOnlineShopExample())
        },
        {
            LightPatternOptionBulbExample,
            new PatternExampleMap("State Pattern >> Light Example", new StatePatternBulbExample())
        },
        {
            StrategyPatternOptionSender,
            new PatternExampleMap("Strategy Pattern >> Sender Example", new StrategyPatternSenderExample())
        },
        {
            StrategyPatternOptionPayment,
            new PatternExampleMap("Strategy Pattern >> Payment Example", new StrategyPatternPaymentExample())
        }
    };
}