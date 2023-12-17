using GofPatterns.Behavioral.StatePattern;
using GofPatterns.Behavioral.StatePattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.Drive;

internal class DriveStateContext : StateContext<DriveStateContext, string>
{
    public DriveStateContext(IState<DriveStateContext, string> defaultState, CarAge carAge) :
        base(defaultState)
    {
        CarAge = carAge;
        FuelLevel = 50;
    }

    public int GetDistance(int fuelConsumption)
    {
        return (10 - fuelConsumption) * FuelLevel * (CarAge.Limit * 2 - CarAge.Age);
    }

    public CarAge CarAge { get; }

    public int FuelLevel { get; }
}