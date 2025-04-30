using MathC.Shared.Interfaces.Common;

namespace MathC.Math.Interfaces;

public interface IMathConverter<TNumber> : ISingleton
    where TNumber : class
{
    TNumber Convert(IEnumerable<string> tokens);
}
