using ConsoleAppBanksParseCurrencies.DB;
using ConsoleAppBanksParseCurrencies.Models;
using ConsoleAppBanksParseCurrencies.Parser;
using ConsoleAppBanksParseCurrencies.Tables;

CurrenciesParser currenciesParser = new CurrenciesParser();
List<Currency> currencies =  currenciesParser.LoadAllCurrencies();

DBManager dbManager = DBManager.Instance;

dbManager.TableCurrencies.Clear();
dbManager.TableCurrencies.AddRange(currencies);