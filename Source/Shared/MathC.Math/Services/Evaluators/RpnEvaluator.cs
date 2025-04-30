using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services.Evaluators;

public class RpnEvaluator<T>(OperationFactory<T> factory, IFormatProvider provider) : IEvaluator<T, List<string>>
    where T : INumber<T>
{
    private readonly OperationFactory<T> _factory = factory;

    private readonly IFormatProvider _provider = provider;

    public T Convert(List<string> rpnTokens)
    {
        var stack = new Stack<T>();

        foreach (var token in rpnTokens)
        {
            if (T.TryParse(token, _provider, out var number))
            {
                stack.Push(number);
            }
            else if (_factory.IsOperation(token))
            {
                var right = stack.Pop();

                var left = stack.Pop();

                var result = _factory.Get(token).Apply(left, right);

                stack.Push(result);
            }
        }

        return stack.Pop();
    }
}
