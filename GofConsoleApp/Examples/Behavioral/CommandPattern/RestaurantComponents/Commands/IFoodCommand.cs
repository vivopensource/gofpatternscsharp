using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;
using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Commands;

internal interface IFoodCommand : ICommand<IFoodRequest> { }