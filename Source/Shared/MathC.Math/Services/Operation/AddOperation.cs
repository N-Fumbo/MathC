using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Operation;

public class AddOperation<T> : IOperation<T>
    where T : INumber<T>
{
    public string Symbol => "+";

    public int Precedence => 1;

    public T Apply(T left, T right) => left + right;
}
