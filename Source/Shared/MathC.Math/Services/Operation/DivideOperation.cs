using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Operation;

public class DivideOperation<T> : IOperation<T>
    where T : INumber<T>
{
    public IReadOnlyList<string> Symbols => ["/"];

    public int Precedence => 2;

    public T Apply(T left, T right)
    {
        if (right == default)
            throw new DivideByZeroException();

        return left / right;
    }
}
