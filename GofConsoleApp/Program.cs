using Core.Console;
using Core.Extensions;
using static System.Console;

using var logFactory = ConsoleExtensions.GetLoggerFactory();
GofConsoleApp.Examples.Execution.Run(new ConsoleLogger(logFactory.CreateLogger("")), new InputReader(In));