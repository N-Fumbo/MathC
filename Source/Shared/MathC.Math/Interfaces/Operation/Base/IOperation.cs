using System.Numerics;

namespace MathC.Math.Interfaces.Operation.Base;

public interface IOperation<T>
    where T : INumber<T>
{
    string Symbol { get; }

    int Precedence { get; }

    T Apply(T left, T right);
}
