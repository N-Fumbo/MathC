using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Math.Services.Converters;

public class RpnConverter<T>(OperationFactory<T> factory) : IMathConverter<List<string>>
    where T : INumber<T>
{
    private readonly OperationFactory<T> _factory = factory;

    public List<string> Convert(List<string> tokens)
    {
        throw new NotImplementedException();
    }
}
