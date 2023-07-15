using ConsoleAppBanksParseCurrencies.Models;
using HtmlAgilityPack;

namespace ConsoleAppBanksParseCurrencies.Parser;

public class CurrenciesParser
{
    private const string url = "https://mainfin.ru/currency";
    private const string xPathExpression = "//tr[@class='row body tr-turn odd']";
    private HtmlWeb htmlWeb;

    public CurrenciesParser()
    {
        htmlWeb = new HtmlWeb();
        htmlWeb.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
    }

    public List<Currency> LoadAllCurrencies()
    {
        HtmlDocument document = htmlWeb.Load(url);

        //foreach (HtmlNode htmlNode in document.DocumentNode.SelectNodes(xPathExpression))
        //{
        //    
        //}
        var a = document.DocumentNode.SelectNodes(xPathExpression);
        
        return null;
    }
}