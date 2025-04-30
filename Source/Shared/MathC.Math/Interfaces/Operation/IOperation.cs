using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces.Operation;

public interface IOperation<T> : ISingleton
    where T : INumber<T>
{
    IReadOnlyList<string> Symbols { get; }

    int Precedence { get; }

    T Apply(T left, T right);
}
