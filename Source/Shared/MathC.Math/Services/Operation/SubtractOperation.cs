using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Operation;

public class SubtractOperation<T> : IOperation<T>
    where T : INumber<T>
{
    public IReadOnlyList<string> Symbols => throw new NotImplementedException();

    public int Precedence => throw new NotImplementedException();

    public T Apply(T left, T right)
    {
        throw new NotImplementedException();
    }
}
