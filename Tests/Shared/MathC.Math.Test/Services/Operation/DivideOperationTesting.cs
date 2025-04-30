using MathC.Math.Services.Operation;

namespace MathC.Math.Test.Services.Operation;

public class DivideOperationTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Divide_Int_RemovesCorrectly()
    {
        var divide = new DivideOperation<int>();

        var result = divide.Apply(10, 5);

        Assert.Equal(2, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Divide_Int_ThrowsDivideByZeroException()
    {
        var divide = new DivideOperation<int>();

        Assert.Throws<DivideByZeroException>(() => divide.Apply(10, 0));
    }
}
