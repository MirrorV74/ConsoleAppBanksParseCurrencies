using System.Globalization;
using System.Text;
using ConsoleAppBanksParseCurrencies.Models;
using Npgsql;

namespace ConsoleAppBanksParseCurrencies.Tables;

public class TableCurrencies
{
    private NpgsqlConnection _connection;

    public TableCurrencies(NpgsqlConnection connection)
    {
        _connection = connection;
    }
    
    public void Clear()
    {
        string sqlRequest = "TRUNCATE currencies RESTART IDENTITY";

        NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

        command.ExecuteNonQuery();
    }

    public void AddRange(List<Currency> currencies)
    {
        StringBuilder sqlRequest = new StringBuilder("insert into currencies (usd_bank_buy, usd_bank_sell, bank_name) values ");
        for (int i = 0; i < currencies.Count-1; i++)
        {
            string currentValue = $"({currencies[i].UsdBankBuy.ToString(new CultureInfo("en-US"))},{currencies[i].UsdBankSell.ToString(new CultureInfo("en-US"))},'{currencies[i].BankName}'),";
            sqlRequest.Append(currentValue);
        }
        
        string lastValue = $"({currencies[currencies.Count-1].UsdBankBuy.ToString(new CultureInfo("en-US"))},{currencies[currencies.Count-1].UsdBankSell.ToString(new CultureInfo("en-US"))},'{currencies[currencies.Count-1].BankName}')";
        sqlRequest.Append(lastValue);

        NpgsqlCommand command = new NpgsqlCommand(sqlRequest.ToString(), _connection);

        command.ExecuteNonQuery();
    }
}