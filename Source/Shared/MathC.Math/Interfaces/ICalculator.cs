using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces;

public interface ICalculator<TNumber> : ISingleton
    where TNumber : INumber<TNumber>
{
    TNumber Evaluate(string expression);
}
