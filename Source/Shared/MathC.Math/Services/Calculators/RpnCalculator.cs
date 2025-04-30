using MathC.Math.Services.Calculators.Base;
using MathC.Math.Services.Converters;
using MathC.Math.Services.Evaluators;
using System.Numerics;

namespace MathC.Math.Services.Calculators;

public class RpnCalculator<T>(
    RpnConverter<T> converter,
    RpnEvaluator<T> evaluator) : Calculator<T, List<string>>(converter, evaluator)

    where T : INumber<T>
{
}
