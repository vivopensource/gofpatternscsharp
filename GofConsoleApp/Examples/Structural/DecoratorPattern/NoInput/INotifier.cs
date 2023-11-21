using GofPattern.Structural.DecoratorPattern;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.NoInput;

internal interface INotifier : IDecoratorComponent<INotifier> { }