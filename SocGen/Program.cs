using System.Globalization;
using SocGen.Entities;
using SocGen.Utilities;

namespace SocGen;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("My Account Manager");
        string path = Path.Combine(Environment.CurrentDirectory, @"account.csv");

        Factory factory = new Factory();
        Rates rates = new Rates(factory.BuildFxRates());
        Account myAccount = new Account(factory.BuildTransaction(path), Common.Currency.EUR);
        myAccount.UpdateTransactionList(rates);

        Console.WriteLine("Choose a date from 01/01/2022 to 01/03/2023 (dd/MM/yyyy)");
        string? dateChoice = Console.ReadLine();
        DateTime AsofDate = DateTime.Parse(dateChoice, new CultureInfo("fr-FR"));

        Console.WriteLine($"Account Value as of {AsofDate.ToString("dd/MM/yyyy")} : {myAccount.AccountValueByDate(AsofDate, Common.Currency.EUR)} €");

        var resultByCategory = myAccount.SortAccountByCategory(3);
        Console.WriteLine($"Top 3 debit : ");

        foreach (var e in resultByCategory)
        {
            Console.WriteLine($"{e.Category} : {e.Amount} €");
        }
        Console.ReadLine();
    }
}

