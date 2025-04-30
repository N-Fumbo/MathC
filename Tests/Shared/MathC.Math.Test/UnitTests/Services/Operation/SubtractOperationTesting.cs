using MathC.Math.Services.Operation;

namespace MathC.Math.Test.UnitTests.Services.Operation;

public class SubtractOperationTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Subtract_Int_MultiplyCorrectly()
    {
        var subtract = new SubtractOperation<int>();

        var result = subtract.Apply(4, 5);

        Assert.Equal(-1, result);
    }
}
