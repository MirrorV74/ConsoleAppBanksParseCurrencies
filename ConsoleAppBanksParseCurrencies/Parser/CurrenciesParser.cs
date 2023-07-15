using System.Globalization;
using ConsoleAppBanksParseCurrencies.Models;
using HtmlAgilityPack;

namespace ConsoleAppBanksParseCurrencies.Parser;

public class CurrenciesParser
{
    private const string _url = "https://mainfin.ru/currency";
    private const string _xPathExpressionEven = "//tr[@class=' row body tr-turn even']";
    private const string _xPathExpressionOdd = "//tr[@class=' row body tr-turn odd']";
    private HtmlWeb _htmlWeb;

    public CurrenciesParser()
    {
        _htmlWeb = new HtmlWeb();
        _htmlWeb.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
    }

    private List<Currency> ParseNodes(HtmlNodeCollection nodes)
    {
        List<Currency> currencies = new List<Currency>();

        foreach (HtmlNode htmlNode in nodes)
        {
            string bankName = htmlNode.ChildNodes[0].InnerText;
            decimal usdBankBuy = decimal.Parse(htmlNode.ChildNodes[1].InnerText, new CultureInfo("en-US"));
            decimal usdBankSell = decimal.Parse(htmlNode.ChildNodes[2].InnerText, new CultureInfo("en-US"));

            currencies.Add(new Currency()
            {
                BankName = bankName,
                UsdBankBuy = usdBankBuy,
                UsdBankSell = usdBankSell
            });
        }

        return currencies;
    }

    public List<Currency> LoadAllCurrencies()
    {
        HtmlDocument document = _htmlWeb.Load(_url);

        HtmlNodeCollection nodesEven = document.DocumentNode.SelectNodes(_xPathExpressionEven);

        HtmlNodeCollection nodesOdd = document.DocumentNode.SelectNodes(_xPathExpressionOdd);

        List<Currency> currencies = new List<Currency>();

        currencies.AddRange(ParseNodes(nodesEven));
        currencies.AddRange(ParseNodes(nodesOdd));

        return currencies;
    }
}