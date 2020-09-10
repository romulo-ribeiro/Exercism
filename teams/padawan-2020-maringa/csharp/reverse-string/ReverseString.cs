using System;
using System.Collections.Immutable;
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var aux = "";
        for (int i = input.Length-1; i>=0 ; i--)
        {
            aux += input[i];
        }
        return aux;
    }
}