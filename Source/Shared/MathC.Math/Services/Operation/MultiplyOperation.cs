using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Operation;

public class MultiplyOperation<T> : IOperation<T>
    where T : INumber<T>
{
    public IReadOnlyList<string> Symbols => ["*"];

    public int Precedence => 2;

    public T Apply(T left, T right) => left * right;
}
