namespace ConsoleApp1;

public class Mocha : CondimentDecorator
{
    private const decimal Price = 30;
    
    public Mocha(Beverage beverage) : base(beverage)
    {
    }

    protected override decimal PrepareCost(decimal cost)
    {
        return cost + Price;
    }

    protected override string PrepareDescription(string description)
    {
        return $"{TrimDescription(description)}. Мокко.";
    }
}