namespace ConsoleApp1;

public class Milk : CondimentDecorator
{
    private decimal Price = 20m;
    
    public Milk(Beverage beverage) : base(beverage)
    {
    }

    protected override decimal PrepareCost(decimal cost)
    {
        return cost + Price;
    }

    protected override string PrepareDescription(string description)
    {
        return $"{TrimDescription(description)}. С молоком.";
    }
}