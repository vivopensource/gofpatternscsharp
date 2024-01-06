using GofPatterns.Structural.DecoratorPattern;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.NoInputExampleComponents;

internal interface INotifier : IDecorator<INotifier> { }