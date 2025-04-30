using MathC.Math.Services;

namespace MathC.Math.Test.Services;

public class CalculatorTesting
{
    private readonly Calculator<double> _calculator = new();

    [Theory]
    [InlineData("2 + 3", 5)]
    [InlineData("2 + 3 * 4", 14)]
    [InlineData("(2 + 3) * 4", 20)]
    [InlineData("1 + 2 * 3 + 4", 11)]
    [InlineData("3.5 + 2.25", 5.75)]
    [InlineData("(2.75 + 3.75) * 4", 26)]
    [InlineData("(10 + 20 + (30 - 20)) * 4", 160)]
    [Trait("Type", "Модульные тесты")]
    public void Evaluate_ValidRequest_ReturnsCorrectResult(string expression, double expected)
    {
        var result = _calculator.Evaluate(expression);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("10 / 0")]
    [InlineData("25 * (2 / 1) * 10 - 3 / 0")]
    [Trait("Type", "Модульные тесты")]
    public void Evaluate_DivisionByZero_ThrowsDivideByZeroException(string expression)
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Evaluate(expression));
    }
}
