using MathC.Math.Interfaces;
using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services.Evaluators;

public class RpnEvaluator<TNumber>(IOperationFactory<TNumber> factory, IFormatProvider provider) : IEvaluator<TNumber, List<string>>
    where TNumber : INumber<TNumber>
{
    private readonly IOperationFactory<TNumber> _factory = factory;

    private readonly IFormatProvider _provider = provider;

    public TNumber Evaluate(List<string> rpnTokens)
    {
        var stack = new Stack<TNumber>();

        foreach (var token in rpnTokens)
        {
            if (TNumber.TryParse(token, _provider, out var number))
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
