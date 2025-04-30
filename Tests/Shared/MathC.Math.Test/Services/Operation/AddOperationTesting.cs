using MathC.Math.Services.Operation;

namespace MathC.Math.Test.Services.Operation;

public class AddOperationTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Add_Int_AddsCorrectly()
    {
        var add = new AddOperation<int>();

        var result = add.Apply(4, 5);

        Assert.Equal(9, result);
    }
}
