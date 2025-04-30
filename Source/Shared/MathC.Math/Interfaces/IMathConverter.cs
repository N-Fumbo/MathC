using MathC.Shared.Interfaces.Common;

namespace MathC.Math.Interfaces;

public interface IMathConverter<T> : ISingleton
    where T : class
{
    T Convert(List<string> tokens);
}
