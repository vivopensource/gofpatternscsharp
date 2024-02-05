namespace GofConsoleApp.Examples.Structural.CompositePattern;

internal class CompositePatternExampleWithInput : BaseExample
{
    protected override bool Execute()
    {
        // Accessories
        IDeliveryItem bag = new DeliveryProduct("Bag", Logger);
        IDeliveryItem shoes = new DeliveryProduct("Shoes", Logger);
        var accessories = new DeliveryBox(50, 40, 40, Logger);
        accessories.Add(bag, shoes);

        // Clothes
        IDeliveryItem shirt = new DeliveryProduct("Shirt", Logger);
        IDeliveryItem pants = new DeliveryProduct("Pants", Logger);
        var clothes = new DeliveryBox(40, 30, 20, Logger);
        clothes.Add(shirt, pants);

        // Delivery
        var delivery = new DeliveryBox(100, 80, 60, Logger);
        delivery.Add(accessories, clothes);
        delivery.Process("Berlin");
        
        return true;
    }
}