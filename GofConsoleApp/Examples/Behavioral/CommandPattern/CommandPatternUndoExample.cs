using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;
using GofConsoleApp.Examples.ExecutionHelpers;
using static GofConsoleApp.Examples.Behavioral.CommandPattern.Enums.EnumProductOperationOptions;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternUndoExample : AbstractExample
{
    protected override bool Execute()
    {
        EnumYesNo shopping;

        var onlineShop = new OnlineShop();

        do
        {
            var inputProduct = AcceptInputString("product name");
            var inputCount = AcceptInputInt("product count");
            var inputOption = AcceptInputEnum(Invalid, "option (Order/Return)");
            if (inputOption == Invalid)
            {
                Logger.Log($"Quitting program due to input: {inputOption}.");
                return false;
            }

            var product = new Product(Logger, inputProduct, inputCount);

            onlineShop.AddCommand(new OrderCommand(product), inputOption == Return);

            shopping = AcceptInputYesNo("option to continue shopping (Yes/No)");

        } while (shopping == EnumYesNo.Yes);

        Logger.Log("---- SUMMARY ----");

        var orderCount = onlineShop.ExecuteCommands();

        Logger.Log($"Orders executed: {orderCount}");

        return true;
    }
}