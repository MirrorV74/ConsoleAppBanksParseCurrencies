using ConsoleAppBanksParseCurrencies.Tables;

namespace ConsoleAppBanksParseCurrencies.DB;

public class DBManager
{
    private static DBManager _instance = null;

    public static DBManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DBManager();
            }
            return _instance;
        }
    }

    public TableCurrencies TableCurrencies { get; private set; }
    
    private DBManager()
    {
        DBConnection dbconection = new DBConnection("194.67.105.79", "vd_banks_user", "12345", "vd_banks_db");
        TableCurrencies = new TableCurrencies(dbconection.Connection);
    }
}