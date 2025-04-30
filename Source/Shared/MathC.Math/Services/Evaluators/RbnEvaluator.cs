using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services.Evaluators;

public class RbnEvaluator<T> : IEvaluator<T, List<string>>
    where T : INumber<T>
{
    public T Convert(List<string> convertedTokens)
    {
        throw new NotImplementedException();
    }
}
