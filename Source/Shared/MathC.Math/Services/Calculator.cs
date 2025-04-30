using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services;

public class Calculator<T> : ICalculator<T>
    where T : INumber<T>
{
    public T Evaluate(string expression)
    {
        throw new NotImplementedException();
    }
}
