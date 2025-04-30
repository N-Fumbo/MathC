using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services.Converters;

public class RpnConverter<T>(OperationFactory<T> factory, IFormatProvider formatProvider) : IMathConverter<List<string>>
    where T : INumber<T>
{
    private readonly OperationFactory<T> _factory = factory;

    private readonly IFormatProvider _formatProvider = formatProvider;

    private const string _openingBracket = "(";

    private const string _closingBracket = ")";

    public List<string> Convert(List<string> tokens)
    {
        var output = new List<string>();

        var operators = new Stack<string>();

        foreach (var token in tokens)
        {
            if (T.TryParse(token, _formatProvider, out _))
            {
                output.Add(token);
            }
            else if (_factory.IsOperation(token))
            {
                while (operators.Count > 0 &&
                       _factory.IsOperation(operators.Peek()) &&
                       _factory.Get(operators.Peek()).Precedence >= _factory.Get(token).Precedence)
                {
                    output.Add(operators.Pop());
                }

                operators.Push(token);
            }
            else if (token == _openingBracket)
            {
                operators.Push(token);
            }
            else if (token == _closingBracket)
            {
                while (operators.Peek() != _openingBracket)
                {
                    output.Add(operators.Pop());
                }

                operators.Pop(); // Удалить "("
            }
        }

        while (operators.Count > 0)
            output.Add(operators.Pop());

        return output;
    }
}
