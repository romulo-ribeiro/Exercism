using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var cleanNumber = Regex.Replace(phoneNumber, @"(^\W*1|\W+|\s+|\D+)", "");
        if (cleanNumber.Length != 10
         || cleanNumber[0] == '0'
         || cleanNumber[0] == '1'
         || cleanNumber[3] == '0'
         || cleanNumber[3] == '1')
        {
            throw new ArgumentException();
        }
        return cleanNumber;
    }
}