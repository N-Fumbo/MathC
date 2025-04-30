using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces.Operation;

public interface IOperation<TNumber> : ISingleton
    where TNumber : INumber<TNumber>
{
    string Symbol { get; }

    int Precedence { get; }

    TNumber Apply(TNumber left, TNumber right);
}
