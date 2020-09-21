using System;
using System.Collections.Generic;
using System.Linq;

public class Reactor
{
    public InputCell CreateInputCell(int value) => new InputCell(value);

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) =>
        new ComputeCell(producers, compute);
}

public abstract class Cell
{
    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            if (value == _value)
                return;
            _value = value;
            Changed?.Invoke(this, _value);
        }
    }
    public event EventHandler<int> Changed;
}

public class InputCell : Cell
{
    public InputCell(int value) => Value = value;
}

public class ComputeCell : Cell
{
    private readonly IEnumerable<Cell> _producers;
    private readonly Func<int[], int> _compute;

    public ComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute)
    {
        _producers = producers;
        _compute = compute;

        foreach (var cell in _producers)
        {
            cell.Changed += ValueChanged;
        }

        Compute();
    }


    private void ValueChanged(object sender, int newValue) => Compute();

    private int Compute() => Value = _compute((from p in _producers select p.Value).ToArray());
}