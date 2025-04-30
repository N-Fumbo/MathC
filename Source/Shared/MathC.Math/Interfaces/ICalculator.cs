using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces;

public interface ICalculator<T> : ISingleton
    where T : INumber<T>
{
    T Evaluate(string expression);
}
