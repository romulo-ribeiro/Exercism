using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var nucleotides = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0,
        };
        foreach (var item in sequence)
        {
            if (!"ACGT".Contains(item)) throw new ArgumentException();
            nucleotides[item] += 1;
        }
        return nucleotides;
    }
}