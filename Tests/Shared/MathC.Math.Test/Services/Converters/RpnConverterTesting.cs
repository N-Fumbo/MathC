using MathC.Math.Interfaces.Operation;
using MathC.Math.Services;
using MathC.Math.Services.Converters;
using MathC.Math.Services.Operation;

namespace MathC.Math.Test.Services.Converters;

public class RpnConverterTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Convert_SimpleExpression_ReturnsCorrectRpn()
    {
        var tokens = new List<string> { "2", "+", "3" };

        var converter = GetConverter();

        var rpn = converter.Convert(tokens);

        var excpected = new[] { "2", "3", "+" };

        Assert.Equal(excpected, rpn);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Convert_WithDifferentPrecedence_ReturnsCorrectRpn()
    {
        var tokens = new List<string> { "2", "+", "3", "*", "4" };

        var converter = GetConverter();

        var rpn = converter.Convert(tokens);

        var excpected = new[] { "2", "3", "4", "*", "+" };

        Assert.Equal(excpected, rpn);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Convert_WithParentheses_ReturnsCorrectRpn()
    {
        var tokens = new List<string> { "(", "2", "+", "3", ")", "*", "4" };
        var converter = GetConverter();

        var rpn = converter.Convert(tokens);

        var excpected = new[] { "2", "3", "+", "4", "*" };

        Assert.Equal(excpected, rpn);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Convert_NestedParentheses_ReturnsCorrectRpn()
    {
        var tokens = new List<string> { "(", "1", "+", "(", "2", "*", "3", ")", ")", "+", "4" };

        var converter = GetConverter();

        var rpn = converter.Convert(tokens);

        var excpected = new[] { "1", "2", "3", "*", "+", "4", "+" };

        Assert.Equal(excpected, rpn);
    }


    private static RpnConverter<double> GetConverter()
    {
        var factory = new OperationFactory<double>();

        factory.Register(new AddOperation<double>());

        factory.Register(new MultiplyOperation<double>());

        return new RpnConverter<double>(factory);
    }

    private class FakeAddOperation : IOperation<double>
    {
        public int Precedence => 1;

        public string Symbol => "+";

        public double Apply(double left, double right) => left + right;
    }

    private class FakeMultiplyOperation : IOperation<double>
    {
        public int Precedence => 2;

        public string Symbol => "*";

        public double Apply(double left, double right) => left * right;
    }
}
