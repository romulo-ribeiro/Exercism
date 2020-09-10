using System;
using System.Collections.Generic;

public class QueueDeque<T> //FILA
{
    public Deque<T> Lista { get; set; }
    public QueueDeque()
    {
        Lista = new Deque<T>();
    }

    public void Enqueue(T value)
    {
        Lista.Unshift(value);
    }


    public T Dequeue()
    {
        return Lista.Pop();
    }
}