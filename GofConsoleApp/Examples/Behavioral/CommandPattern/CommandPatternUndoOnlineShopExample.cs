using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;
using GofConsoleApp.Examples.ExecutionHelpers;
using static GofConsoleApp.Examples.Behavioral.CommandPattern.Enums.EnumProductOperationOptions;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternUndoOnlineShopExample : AbstractExample
{
    protected override bool Execute()
    {
        EnumYesNo shopping;

        var onlineShop = new OnlineShop(Logger); // Invoker

        do
        {
            var inputOption = AcceptInputEnum(Invalid, "order process", Invalid);
            if (inputOption == Invalid)
                return Logger.LogAndReturnFalse($"Quitting program due to input: {inputOption}.");

            var inputProduct = AcceptInputString("product name");
            if (inputOption == Purchase)
                onlineShop.PurchaseProduct(inputProduct);
            else
                onlineShop.ReturnProduct(inputProduct);

            shopping = AcceptInputYesNo("input to continue shopping");

        } while (shopping == EnumYesNo.Yes);

        Logger.Log("---- ORDER SUMMARY ----");

        var orderCount = onlineShop.CheckOut();

        Logger.Log($"Total transactions: {orderCount}");

        return true;
    }
}