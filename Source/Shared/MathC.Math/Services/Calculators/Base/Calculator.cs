using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services.Calculators.Base;

public class Calculator<TNumber, TConverter>(
    IMathConverter<TConverter> converter,
    IEvaluator<TNumber, TConverter> evaluator) : ICalculator<TNumber>

    where TNumber : INumber<TNumber>
    where TConverter : class
{
    private readonly IMathConverter<TConverter> _converter = converter;

    private readonly IEvaluator<TNumber, TConverter> _evaluator = evaluator;

    public virtual TNumber Evaluate(string expression)
    {
        var tokens = Tokenizer.Tokenize(expression);

        var convetredTokens = _converter.Convert(tokens);

        var result = _evaluator.Convert(convetredTokens);

        return result;
    }
}
