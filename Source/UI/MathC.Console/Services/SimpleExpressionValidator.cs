using MathC.Console.Interfaces;

namespace MathC.Console.Services;

public class SimpleExpressionValidator : IExpressionValidator
{
    public bool IsValid(string expression)
    {
        return string.IsNullOrWhiteSpace(expression) is false;
    }
}
