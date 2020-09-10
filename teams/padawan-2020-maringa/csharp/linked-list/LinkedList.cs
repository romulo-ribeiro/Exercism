using System.Collections.Generic;
using System.Linq;

public class Deque<T>
{
    public LinkedList<T> _list { get; set; } = new LinkedList<T>();

    public void Push(T value)
    {
        _list.AddLast(value);
    }

    public T Pop()
    {
        T value = _list.Last();
        _list.RemoveLast();
        return value;
    }

    public void Unshift(T value)
    {
        _list.AddFirst(value);
    }

    public T Shift()
    {
        T value = _list.First();
        _list.RemoveFirst();
        return value;
    }
}