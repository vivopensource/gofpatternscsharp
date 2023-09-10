using Core.Console;
using Core.Extensions;

using var logFactory = ConsoleExtensions.GetLoggerFactory();
var logger = new ConsoleLogger(logFactory.CreateLogger(string.Empty));
var inputReader = new InputReader(Console.In);
GofConsoleApp.Examples.Execution.Run(logger, inputReader);