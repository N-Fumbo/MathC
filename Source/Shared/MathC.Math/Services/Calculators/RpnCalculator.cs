using MathC.Math.Services.Calculators.Base;
using MathC.Math.Services.Converters;
using MathC.Math.Services.Evaluators;
using System.Numerics;

namespace MathC.Math.Services.Calculators;

public class RpnCalculator<TNumber>(
    RpnConverter<TNumber> converter,
    RpnEvaluator<TNumber> evaluator) : Calculator<TNumber, List<string>>(converter, evaluator)

    where TNumber : INumber<TNumber>
{

}
