using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces.Operation;

public interface IOperationFactory<T> : ISingleton
    where T : INumber<T>
{
    void Register(IOperation<T> operation);

    bool TryGet(string symbol, out IOperation<T> operation);

    bool IsOperation(string token);

    IOperation<T> Get(string symbol);
}
