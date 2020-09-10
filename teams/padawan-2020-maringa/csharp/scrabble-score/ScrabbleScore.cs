using System;
using System.Collections.Generic;

public static class ScrabbleScore
{
    static Dictionary<string, int> letterValues = new Dictionary<string, int>
    {
        ["AEIOULNRST"] = 1,
        ["DG"] = 2,
        ["BCMP"] = 3,
        ["FHVWY"] = 4,
        ["K"] = 5,
        ["JX"] = 8,
        ["QZ"] = 10,
    };
    public static int Score(string input)
    {
        int score = 0;
        foreach (char letter in input)
        {
            foreach (string key in letterValues.Keys)
            {
                score += (key.Contains(char.ToUpper(letter)))? letterValues[key]: 0 ;
            }

        }
        return score;
    }
}