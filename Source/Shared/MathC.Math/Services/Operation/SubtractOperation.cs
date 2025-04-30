using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Operation;

public class SubtractOperation<TNumber> : IOperation<TNumber>
    where TNumber : INumber<TNumber>
{
    public virtual string Symbol => "-";

    public int Precedence => 1;

    public TNumber Apply(TNumber left, TNumber right) => left - right;
}
