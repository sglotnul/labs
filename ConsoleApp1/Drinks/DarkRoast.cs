namespace ConsoleApp1;

public class DarkRoast : Beverage
{
    public override string GetDescription()
        => "Dark Roast. Изготовлен из смеси отборных зерен арабики и робусты темной обжарки.";

    public override decimal Cost()
        => 240m;
}