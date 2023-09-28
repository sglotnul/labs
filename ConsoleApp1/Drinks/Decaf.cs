namespace ConsoleApp1;

public class Decaf : Beverage
{
    public override string GetDescription()
        => "Decaf. Кофе без кофеина";

    public override decimal Cost()
        => 200m;
}