using MathC.Math.Interfaces.Operation;
using MathC.Math.Services;

namespace MathC.Math.Test.Services;

public class OperationFactoryTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Register_AddOperation_ShouldBeRecognized()
    {
        var factory = new OperationFactory<int>();

        var add = new FakeAddOperation();

        factory.Register(add);

        Assert.True(factory.IsOperation("+"));
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Get_RegisteredOperation_ReturnsCorrectInstance()
    {
        var factory = new OperationFactory<int>();

        var add = new FakeAddOperation();

        factory.Register(add);

        var op = factory.Get("+");

        Assert.NotNull(op);

        Assert.Equal(1, op.Precedence);

        Assert.Equal(5, op.Apply(2, 3));
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void TryGet_ReturnsTrue_AndCorrectOperation()
    {
        var factory = new OperationFactory<int>();

        var add = new FakeAddOperation();

        factory.Register(add);

        var result = factory.TryGet("+", out var op);

        Assert.True(result);

        Assert.NotNull(op);

        Assert.Equal(5, op.Apply(2, 3));
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void TryGet_ReturnsFalse_WhenNotFound()
    {
        var factory = new OperationFactory<int>();

        var result = factory.TryGet("*", out var op);

        Assert.False(result);

        Assert.Null(op);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Get_ThrowsException_WhenNotRegistered()
    {
        var factory = new OperationFactory<int>();

        Assert.Throws<KeyNotFoundException>(() => factory.Get("/"));
    }

    private class FakeAddOperation : IOperation<int>
    {
        public IReadOnlyList<string> Symbols => ["+"];

        public int Precedence => 1;

        public int Apply(int left, int right) => left + right;
    }
}
