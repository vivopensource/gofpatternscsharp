namespace GofPattern.Structural.Command;

public class Invoker
{
    private IList<Processor> _processors;

    public Invoker()
    {
        _processors = new List<Processor>();
    }

    public void Register(Processor processor)
    {
        _processors.Add(processor);
    }

    public void Invoke()
    {
        if (_processors.Count < 1)
        {
            Console.WriteLine("No phone numbers available to start communication.");
            return;
        }

        foreach (var processor in _processors)
            processor.Execute();

        _processors = new List<Processor>();
    }
}

public class Processor
{
    public void Execute()
    {
        
    }
}