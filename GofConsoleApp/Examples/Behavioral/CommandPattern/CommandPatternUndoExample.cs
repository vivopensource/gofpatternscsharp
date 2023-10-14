using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;
using GofConsoleApp.Examples.ExecutionHelpers;
using static GofConsoleApp.Examples.Behavioral.CommandPattern.Enums.EnumProductOperationOptions;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternUndoExample : AbstractExample
{
    protected override bool Execute()
    {
        EnumYesNo shopping;

        var onlineShop = new OnlineShop(Logger); // Invoker

        do
        {
            var inputProduct = AcceptInputString("product name");
            var inputOption = AcceptInputEnum(Invalid, "option (Order/Return)");

            if (inputOption == Invalid)
                return Logger.LogAndReturn($"Quitting program due to input: {inputOption}.", false);

            if (inputOption == Purchase)
                onlineShop.PurchaseProduct(inputProduct);
            else
                onlineShop.ReturnProduct(inputProduct);

            shopping = AcceptInputYesNo("option to continue shopping (Yes/No)");

        } while (shopping == EnumYesNo.Yes);

        Logger.Log("---- SUMMARY ----");

        var orderCount = onlineShop.CheckOut();

        Logger.Log($"Total transactions: {orderCount}");

        return true;
    }
}