namespace ConsoleApp1;

public class Soy : CondimentDecorator
{
    private const decimal Price = 10;
    
    public Soy(Beverage beverage) : base(beverage)
    {
    }

    protected override decimal PrepareCost(decimal cost)
    {
        return cost + Price;
    }

    protected override string PrepareDescription(string description)
    {
        return $"{TrimDescription(description)}. Соевый.";
    }
}