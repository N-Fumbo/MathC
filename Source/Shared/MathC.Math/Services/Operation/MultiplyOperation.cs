using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Operation;

public class MultiplyOperation<TNumber> : IOperation<TNumber>
    where TNumber : INumber<TNumber>
{
    public virtual string Symbol => "*";

    public int Precedence => 2;

    public TNumber Apply(TNumber left, TNumber right) => left * right;
}
