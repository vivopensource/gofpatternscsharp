using GofConsoleApp.Examples.Behavioral.CommandPattern.OnlineShopComponents;
using GofConsoleApp.Examples.ExecutionHelpers;
using static GofConsoleApp.Examples.Behavioral.CommandPattern.OnlineShopComponents.EnumProductOperationOptions;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternUndoOnlineShopExample : BaseExample
{
    protected override bool Execute()
    {
        EnumYesNo shopping;

        var onlineShop = new OnlineShopAsInvoker(Logger); // Invoker

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