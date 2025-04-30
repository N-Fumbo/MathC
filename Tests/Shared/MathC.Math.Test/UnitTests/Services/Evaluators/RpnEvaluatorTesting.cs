using MathC.Math.Interfaces.Operation;
using MathC.Math.Services;
using MathC.Math.Services.Evaluators;
using System.Globalization;

namespace MathC.Math.Test.UnitTests.Services.Evaluators;

public class RpnEvaluatorTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Evaluate_SimpleAddition_ReturnsCorrectResult()
    {
        var rpnTokens = new List<string> { "2", "3", "+" };
        var evaluator = GetEvaluator();

        var result = evaluator.Evaluate(rpnTokens);

        Assert.Equal(5, result); // 2 + 3
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Evaluate_MultiplicationBeforeAddition_ReturnsCorrectResult()
    {
        var rpnTokens = new List<string> { "2", "3", "4", "*", "+" };
        var evaluator = GetEvaluator();

        var result = evaluator.Evaluate(rpnTokens);

        Assert.Equal(14, result); // (3 * 4) + 2 = 14
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Evaluate_NestedOperations_ReturnsCorrectResult()
    {
        var rpnTokens = new List<string> { "2", "3", "+", "4", "*" };
        var evaluator = GetEvaluator();

        var result = evaluator.Evaluate(rpnTokens);

        Assert.Equal(20, result); // (2 + 3) * 4 = 20
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Evaluate_ComplexExpression_ReturnsCorrectResult()
    {
        var rpnTokens = new List<string> { "1", "2", "3", "*", "+", "4", "+" };
        var evaluator = GetEvaluator();

        var result = evaluator.Evaluate(rpnTokens);

        Assert.Equal(11, result); // 1 + (2 * 3) + 4 = 11
    }

    private static RpnEvaluator<double> GetEvaluator()
    {
        var factory = new OperationFactory<double>();

        factory.Register(new FakeAddOperation());

        factory.Register(new FakeMultiplyOperation());

        return new RpnEvaluator<double>(factory, CultureInfo.InvariantCulture);
    }

    private class FakeAddOperation : IOperation<double>
    {
        public string Symbol => "+";

        public int Precedence => 1;

        public double Apply(double left, double right) => left + right;
    }

    private class FakeMultiplyOperation : IOperation<double>
    {
        public string Symbol => "*";

        public int Precedence => 2;

        public double Apply(double left, double right) => left * right;
    }
}
