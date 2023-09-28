namespace ConsoleApp1;

public abstract class CondimentDecorator : Beverage
{
    private readonly Beverage _beverage;

    protected CondimentDecorator(Beverage beverage)
    {
        _beverage = beverage;
    } 
    
    public override string GetDescription()
    {
        return PrepareDescription(_beverage.GetDescription());
    }

    public override decimal Cost()
    {
        return Math.Round(PrepareCost(_beverage.Cost()), 2);
    }

    protected abstract decimal PrepareCost(decimal cost);
    protected abstract string PrepareDescription(string description);

    protected static string TrimDescription(string description)
    {
        return description.Trim(' ', '.');
    }
}