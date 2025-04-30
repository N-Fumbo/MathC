using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces;

public interface IEvaluator<TNumber, TParam> : ISingleton
    where TNumber : INumber<TNumber>
    where TParam : class
{
    TNumber Evaluate(TParam convertedTokens);
}
