using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;

public class HighScores
{
    private List<int> _list;
    public HighScores(List<int> list)
    {
        _list = list;
    }

    public List<int> Scores()
    {
        return _list;
    }

    public int Latest()
    {
        return _list.Last();
    }

    public int PersonalBest()
    {
        return _list.Max();
    }

    public List<int> PersonalTopThree()
    {
        return _list.OrderBy(q => -q).Take(3).ToList();
    }
}