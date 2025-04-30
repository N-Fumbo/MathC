using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services.Evaluators;

public class RpnEvaluator<T>(OperationFactory<T> factory) : IEvaluator<T, List<string>>
    where T : INumber<T>
{
    private readonly OperationFactory<T> _factory = factory;

    public T Convert(List<string> convertedTokens)
    {
        throw new NotImplementedException();
    }
}
