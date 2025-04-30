using MathC.Shared.Interfaces.Common;
using System.Numerics;

namespace MathC.Math.Interfaces.Operation;

public interface IOperationFactory<TNumber> : ISingleton
    where TNumber : INumber<TNumber>
{
    void Register(IOperation<TNumber> operation);

    bool TryGet(string symbol, out IOperation<TNumber> operation);

    bool IsOperation(string symbol);

    IOperation<TNumber> Get(string symbol);
}
