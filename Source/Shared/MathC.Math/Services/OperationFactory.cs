using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services;

public class OperationFactory<T> : IOperationFactory<T>
    where T : INumber<T>
{
    public OperationFactory()
    {
        
    }

    public IOperation<T> Get(string symbol)
    {
        throw new NotImplementedException();
    }

    public bool IsOperation(string token)
    {
        throw new NotImplementedException();
    }

    public void Register(IOperation<T> operation)
    {
        throw new NotImplementedException();
    }

    public bool TryGet(string symbol, out IOperation<T> operation)
    {
        throw new NotImplementedException();
    }
}
