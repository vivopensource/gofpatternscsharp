namespace GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents;

internal class CarAge
{
    public const int Limit = 10;

    private CarAge(int age)
    {
        Age = age;
    }

    public int Age { get; private set; }

    public static CarAge Get()
    {
        var random = new Random();
        return new CarAge(random.Next(1, Limit));
    }
}