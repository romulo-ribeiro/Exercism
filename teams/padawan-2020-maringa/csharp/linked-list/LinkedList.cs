using System.Collections.Generic;
using System.Linq;

public class Item<T>
{
    public T Valor { get; set; }
    public Item<T> Anterior { get; set; }
    public Item<T> Proximo { get; set; }
}
public class Deque<T>
{
    private Item<T> primeiro;
    /// <summary>
    /// Adds a value to the end of a linked list
    /// </summary>
    /// <param name="value"></param>
    public void Push(T value)
    {
        if (primeiro is null)
        {
            primeiro = new Item<T> { Valor = value};
            return;
        }

        Item<T> ultimo = primeiro;

        while(!(ultimo.Proximo is null))
        {
            ultimo = primeiro.Proximo;
        }
        ultimo.Proximo = new Item<T> { Valor = value, Anterior = ultimo };
    }
    /// <summary>
    /// Returns the last element of a linked list
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        Item<T> ultimo = primeiro;
        while (!(ultimo.Proximo is null))
        {
            ultimo = ultimo.Proximo;
        }
        
        T pop = ultimo.Valor;
        ultimo.Valor = default(T);
        if (!(ultimo.Anterior is null))
        {
            (ultimo.Anterior).Proximo = null;
            return pop;
        }
        else
        {
            primeiro.Valor = default(T);
        }
        return pop;
    }
    /// <summary>
    /// Adds a value to the start of a linked list
    /// </summary>
    /// <param name="value"></param>
    public void Unshift(T value)
    {
        if (primeiro is null)
        {
            primeiro = new Item<T> { Valor = value };
            return;
        }

        Item<T> segundo = primeiro;
        primeiro = new Item<T> { Valor = value, Proximo = segundo };
        segundo.Anterior = primeiro;
    }
    /// <summary>
    /// Returns the first element of a linked list
    /// </summary>
    /// <returns></returns>
    public T Shift()
    {
        if (primeiro.Proximo is null)
        {
            T last = primeiro.Valor;
            primeiro.Valor = default(T);
            return last;
        }

        Item<T> segundo = primeiro.Proximo;
        T shift = primeiro.Valor;
        primeiro = segundo;
        primeiro.Anterior = null;
        return shift;
    }
}