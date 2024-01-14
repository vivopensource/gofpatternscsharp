using GofPatterns.Creational.BuilderPattern;

namespace GofConsoleApp.Examples.Creational.BuilderPattern;

internal class BuilderPatternExample : BaseExample
{
    protected override bool Execute()
    {
        Logger.Log("To exit, please provide a non-numerical value.");

        var builder = new AdditionBuilder();

        while (true)
        {
            var value = AcceptInputString("input to add");

            if (!decimal.TryParse(value, out var input))
                break;

            builder.Append(input);
        }

        Logger.Log("Addition output: ", builder.Output());

        return true;
    }
}

internal class AdditionBuilder : Builder<decimal>
{
    public AdditionBuilder() {}

    public AdditionBuilder(decimal input) : base(input) {}

    private decimal num;

    public override decimal Output() => num;

    protected override void Build(decimal input) => num = decimal.Add(num, input);
}