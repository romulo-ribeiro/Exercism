using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength>numbers.Length || sliceLength<=0)
        {
            throw new ArgumentException();
        };
        var position = 0;
        List<string> series = new List<string>();
        while (position+sliceLength<=numbers.Length)
        {
            series.Add(numbers.Substring(position, sliceLength));
            position++;
        }
        return series.ToArray();
    }
}