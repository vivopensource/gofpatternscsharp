using Core.Logging;
using GofConsoleApp.Examples.Behavioral.Command;
using Microsoft.Extensions.Logging;

var logFactory = LogExtensions.GetLoggerFactory();
var log = logFactory.CreateLogger<Program>();

var cie = new CommandInvokerExample(new CustomLogger(log));

cie.DeliverPizza(2);
cie.DeliverBurger(5);
cie.EatBurger(6);
cie.InvokeOrder();
cie.EatBurger(3);
cie.EatPizza(3);
cie.InvokeOrder();


logFactory.Dispose(100);