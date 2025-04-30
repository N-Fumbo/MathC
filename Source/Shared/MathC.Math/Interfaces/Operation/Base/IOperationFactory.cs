using System.Numerics;

namespace MathC.Math.Interfaces.Operation.Base;

public interface IOperationFactory<T>
    where T : INumber<T>
{
    void Register(IOperation<T> operation);

    bool TryGet(string symbol, out IOperation<T> operation);

    bool IsOperation(string token);

    IOperation<T> Get(string symbol);
}
