using System;
using System.Reflection.Metadata.Ecma335;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException();
        int hammingDistance = 0;
        for (int i = 0; i < firstStrand.Length; i++)
        {
            hammingDistance += (firstStrand[i] != secondStrand[i]) ?  1 : 0;
        }
        return hammingDistance;
    }
}