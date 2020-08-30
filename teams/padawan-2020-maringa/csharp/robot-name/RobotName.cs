using System;
using System.Collections.Generic;

public class Robot
{
    private readonly Random _random = new Random();
    private static HashSet<string> _names = new HashSet<string>();

    public Robot()
    {
        Reset();
    }
    public string Name { get; private set; }

    public void Reset()
    {
        Name = GenerateName();
    }
    public string GenerateName()
    {
        string robotName = "";
        do
        {
            for (int i = 0; i < 5; i++)
            {
                robotName += (i < 2) ? ((char)_random.Next(65, 90)).ToString() : _random.Next(0, 9).ToString();
            }
        } while (!UniqueName(robotName));
        return robotName.ToString();
    }

    public bool UniqueName(string name)
    {
        return _names.Add(name);
    }
}