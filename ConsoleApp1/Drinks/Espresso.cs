namespace ConsoleApp1;

public class Espresso : Beverage
{
    public override string GetDescription()
        => "Espresso. Маленький напиток, приготовленный из достаточно большого количества утрамбованного молотого кофе, через который под давлением проходит вода.";

    public override decimal Cost()
        => 180m;
}