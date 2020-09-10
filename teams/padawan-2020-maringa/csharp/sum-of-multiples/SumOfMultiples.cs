using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> numMult = new HashSet<int>();
        var multiplesNoZeros = multiples.Where(q => q != 0);
        foreach (var num in multiplesNoZeros)
        {
            var i = 1;
            while ((num * i) <= max)
            {
                if ((num * i) >= max) { break; }
                else
                {
                    numMult.Add((num * i));
                }
                i++;
            }
        }
        return numMult.Sum();
    }
}