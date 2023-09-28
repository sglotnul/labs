using ConsoleApp1;

var drinks = new Beverage[]
{
    new DarkRoast(),
    new Decaf(),
    new Espresso(),
    new HouseBlend()
};

Console.WriteLine("В наличии:");

foreach (var drink in drinks)
{
    ShowDrink(drink);
    Console.Write("\t- ");
    ShowDrink(new Milk(drink));
    Console.Write("\t- ");
    ShowDrink(new Soy(drink));
    Console.Write("\t- ");
    ShowDrink(new Mocha(drink));
    Console.Write("\t- ");
    ShowDrink(new Whip(drink));
}

void ShowDrink(Beverage drink)
{
    Console.Write($"{drink.Cost()} руб. {drink.GetDescription()}");
    Console.WriteLine();
}