using GofConsoleApp.Examples.Behavioral.CommandPattern;
using GofConsoleApp.Examples.Behavioral.CorPattern;
using GofConsoleApp.Examples.Behavioral.MediatorPattern;
using GofConsoleApp.Examples.Behavioral.StatePattern;
using GofConsoleApp.Examples.Behavioral.StrategyPattern;
using GofConsoleApp.Examples.Creational.AbstractFactoryPattern;
using GofConsoleApp.Examples.Creational.BuilderPattern;
using GofConsoleApp.Examples.Creational.FactoryPattern;
using GofConsoleApp.Examples.Structural.AdapterPattern;
using GofConsoleApp.Examples.Structural.DecoratorPattern;
using GofConsoleApp.Examples.Structural.FlyweightPattern;
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
    internal const string AdapterPatternOption = "13";
    internal const string FlyweightPatternOption = "14";
    internal const string MediatorPatternOption = "15";
    internal const string ChainOfResponsibilityPatternOption = "21";
    internal const string ChainOfResponsibilityPatternOption2 = "21.2";
    internal const string ChainOfResponsibilityPatternOption3 = "21.3";
    internal const string CommandPatternOption = "22";
    internal const string CommandPatternUndoOption = "22.2";
    internal const string StatePatternOptionBulbExample = "23";
    internal const string StatePatternOptionDriveExample = "23.2";
    internal const string StrategyPatternOptionSender = "24";
    internal const string StrategyPatternOptionPayment = "24.2";
    internal const string FactoryOption = "31";
    internal const string AbstractFactoryOption = "32";
    internal const string BuilderPatternOption = "33";

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
            new PatternExampleMap("Proxy Pattern >> Cached Output", new ConfigProviderExampleCachedOutput())
        },
        {
            ProxyPatternOptionBoundedInput,
            new PatternExampleMap("Proxy Pattern >> Bounded Input", new NewsChannelExampleBoundedAccess())
        },
        {
            ProxyPatternOptionBoundedInputOutput,
            new PatternExampleMap("Proxy Pattern >> Bounded Input with Output", new UserInterfaceExampleBoundedAccess())
        },
        {
            AdapterPatternOption,
            new PatternExampleMap("Adapter Pattern >> Adaptee:Employee , Target:Traveller", new AdapterPatternExample())
        },
        {
            FlyweightPatternOption,
            new PatternExampleMap("Flyweight Pattern >> Drawing shapes", new FlyweightPatternExample())
        },
        {
            MediatorPatternOption,
            new PatternExampleMap("Flyweight Pattern >> Drawing shapes", new MediatorPatternExample())
        },

        // Behavioral Patterns
        {
            ChainOfResponsibilityPatternOption,
            new PatternExampleMap("Chain Of Responsibility Pattern >> Input",
                new CorPatternExample())
        },
        {
            ChainOfResponsibilityPatternOption2,
            new PatternExampleMap("Chain Of Responsibility Pattern >> Input & Output",
                new CorPatternExampleWithOutput())
        },
        {
            ChainOfResponsibilityPatternOption3,
            new PatternExampleMap("Chain Of Responsibility Pattern >> Complex",
                new CorPatternComplexExample())
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
            StatePatternOptionBulbExample,
            new PatternExampleMap("State Pattern >> Bulb Example", new StatePatternBulbExample())
        },
        {
            StatePatternOptionDriveExample,
            new PatternExampleMap("State Pattern >> Drive Example", new StatePatternDriveExample())
        },
        {
            StrategyPatternOptionSender,
            new PatternExampleMap("Strategy Pattern >> Sender Example", new StrategyPatternSenderExample())
        },
        {
            StrategyPatternOptionPayment,
            new PatternExampleMap("Strategy Pattern >> Payment Example", new StrategyPatternPaymentExample())
        },

        // Creational Patterns
        {
            FactoryOption,
            new PatternExampleMap("Factory Pattern", new FactoryPatternExample())
        },
        {
            AbstractFactoryOption,
            new PatternExampleMap("Abstract Factory Pattern", new AbstractFactoryPatternExample())
        },
        {
            BuilderPatternOption,
            new PatternExampleMap("Builder Pattern", new BuilderPatternExample())
        }
    };
}