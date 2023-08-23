using GofPattern.Structural.DecoratorPattern;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.Input;

internal interface INotifier : IDecoratorComponent<INotifier, string> { }