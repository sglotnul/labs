namespace ConsoleApp1;

public class HouseBlend : Beverage
{
    public override string GetDescription()
        => "House Blend. Сбалансированный кофе с минимальной кислотностью и ореховыми нотами.";

    public override decimal Cost()
        => 260m;
}