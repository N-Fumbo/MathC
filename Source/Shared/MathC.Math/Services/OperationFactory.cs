using MathC.Math.Interfaces.Operation;
using System.Numerics;

namespace MathC.Math.Services;

public class OperationFactory<TNumber> : IOperationFactory<TNumber>
    where TNumber : INumber<TNumber>
{
    private readonly Dictionary<string, IOperation<TNumber>> _operations = [];

    public IOperation<TNumber> Get(string symbol)
    {
        if (_operations.TryGetValue(symbol, out var op))
        {
            return op;
        }
        else
        {
            throw new KeyNotFoundException($"Operation '{symbol}' not found.");
        }
    }

    public bool IsOperation(string symbol) =>
        _operations.ContainsKey(symbol);

    public void Register(IOperation<TNumber> operation) =>
        _operations.Add(operation.Symbol, operation);

    public bool TryGet(string symbol, out IOperation<TNumber> operation) =>
        _operations.TryGetValue(symbol, out operation);
}
