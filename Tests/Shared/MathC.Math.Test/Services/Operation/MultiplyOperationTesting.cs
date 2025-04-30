using MathC.Math.Services.Operation;

namespace MathC.Math.Test.Services.Operation;

public class MultiplyOperationTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Multiply_Int_MultiplyCorrectly()
    {
        var multiply = new MultiplyOperation<int>();
        
        var result = multiply.Apply(4, 5);
        
        Assert.Equal(20, result);
    }
}
