using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("drinks")]
public class MainController : Controller
{
    [HttpGet("")]
    public ContentResult Select()
    {
        return new ContentResult
        {
            ContentType = "text/html",
            Content =
                """
                <html>
                    <meta charset="utf-8">
                    <body>
                        <form method="POST" action="/drinks/choose">
                            <select name="drink">
                                <option value="tea">Чай</option>
                                <option value="coffee">Кофе</option>
                                <option value="juice">Сок</option>
                                <option value="alcohol">Хихи</option>
                            </select><br/>
                            <input type="text" name="milk" value="0"><br/>
                            <input type="text" name="sugar" value="0"><br/>
                            <button type="submit">Ok</button>
                        </form>
                    </body>
                </html>
                """
        };
    }
    
    [HttpPost("choose")]
    public ContentResult Order(string drink, int? milk, int? sugar)
    {
        if (!milk.HasValue)
            throw new ValidationException("invalid milk value");
        
        if (!sugar.HasValue)
            throw new ValidationException("invalid sugar value");

        var drinkType = drink switch
        {
            "tea" => "Чай",
            "coffee" => "Кофе",
            "juice" => "Сок",
            "alcohol" => "Хихи",
            _ => throw new ValidationException("invalid drink type")
        };

        return new ContentResult
        {
            ContentType = "text/html",
            Content =
                $"""
                <html>
                    <meta charset="utf-8">
                    <body>
                        <span>Вы выбрали следующий напиток</span><br/>
                        <span>Тип напитка: {drinkType}</span><br/>
                        <span>Молоко: {milk}</span><br/>
                        <span>Сахар: {sugar}</span><br/>
                        <a href="/drinks">На главную</a>
                    </body>
                </html>
                """
        };
    }
}