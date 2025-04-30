using MathC.Math.Services;
using MathC.Math.Services.Calculators;
using MathC.Math.Services.Converters;
using MathC.Math.Services.Evaluators;
using MathC.Math.Services.Operation;
using System.Globalization;

namespace MathC.Math.Test.IntegrationTests.Services.Calculators;

public class RpnCalculatorTesting
{
    private readonly RpnCalculator<double> _calculator = GetCalculator();

    [Theory]
    [InlineData("2 + 3", 5)]
    [InlineData("2 + 3 * 4", 14)]
    [InlineData("(2 + 3) * 4", 20)]
    [InlineData("1 + 2 * 3 + 4", 11)]
    [InlineData("3.5 + 2.25", 5.75)]
    [InlineData("(2.75 + 3.75) * 4", 26)]
    [InlineData("(10 + 20 + (30 - 20)) * 4", 160)]
    [Trait("Type", "Интеграционный тест")]
    public void Evaluate_ValidRequest_ReturnsCorrectResult(string expression, double expected)
    {
        var result = _calculator.Evaluate(expression);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("10 / 0")]
    [InlineData("25 * (2 / 1) * 10 - 3 / 0")]
    [Trait("Type", "Интеграционный тест")]
    public void Evaluate_DivisionByZero_ThrowsDivideByZeroException(string expression)
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Evaluate(expression));
    }

    private static RpnCalculator<double> GetCalculator()
    {
        OperationFactory<double> factory = new();

        factory.Register(new AddOperation<double>());

        factory.Register(new DivideOperation<double>());

        factory.Register(new MultiplyOperation<double>());

        factory.Register(new SubtractOperation<double>());

        RpnConverter<double> converter = new(factory, CultureInfo.InvariantCulture);

        RpnEvaluator<double> evaluator = new(factory, CultureInfo.InvariantCulture);

        return new RpnCalculator<double>(converter, evaluator);
    }
}
