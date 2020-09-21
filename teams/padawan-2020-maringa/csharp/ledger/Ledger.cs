using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string description, decimal change)
    {
        Date = date;
        Description = description;
        Change = change;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public static class Ledger
{
    private const string LOCALE_NL = "nl-NL";
    private const string LOCALE_US = "en-US";

    public static LedgerEntry CreateEntry(string date, string description, int change) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), description, change / 100.0m);

    private static (CultureInfo, string) CreateCulture(string currency, string locale)
    {
        if (currency != "USD" && currency != "EUR" || locale != LOCALE_NL && locale != LOCALE_US)
            throw new ArgumentException("Invalid currency or location");

        var culture = new CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = (currency == "USD") ? "$" : "€";
        culture.NumberFormat.CurrencyNegativePattern = (locale == LOCALE_US) ? 0 : 12;
        culture.DateTimeFormat.ShortDatePattern = (locale == LOCALE_US) ? "MM/dd/yyyy" : "dd/MM/yyyy";

        var header = (locale == LOCALE_US) ? 
            $"{"Date",-11}|{" Description",-27}|{" Change",-14}" : 
            $"{"Datum",-11}|{" Omschrijving",-27}|{" Verandering",-14}";

        return (culture, header);
    }

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string description) =>
        description.Length > 25 ? $"{description.Substring(0, 22)}..." : description;

    private static string Change(IFormatProvider culture, decimal change) =>
        change < 0.0m ? change.ToString("C", culture) : change.ToString("C", culture) + " ";

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
    {
        var formatted = new StringBuilder();

        formatted.Append(Date(culture, entry.Date));
        formatted.Append(" | ");
        formatted.Append(string.Format("{0,-25}", Description(entry.Description)));
        formatted.Append(" | ");
        formatted.Append(string.Format("{0,13}", Change(culture, entry.Change)));

        return formatted.ToString();
    }

    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries) =>
        entries.Where(e => e.Change < 0).OrderBy(x => $"{x.Date}@{x.Description}@{x.Change}").
            Union(entries.Where(e => e.Change >= 0).OrderBy(x => $"{x.Date}@{x.Description}@{x.Change}"));

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = new StringBuilder();

        var (culture, header) = CreateCulture(currency, locale);
        formatted.Append(header);

        if (entries.Length > 0)
        {
            var entriesForOutput = sort(entries);

            for (var i = 0; i < entriesForOutput.Count(); i++)
                formatted.Append("\n" + PrintEntry(culture, entriesForOutput.Skip(i).First()));
        }
        return formatted.ToString();
    }
}
