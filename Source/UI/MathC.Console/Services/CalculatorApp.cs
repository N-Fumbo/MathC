using MathC.Console.Interfaces;
using MathC.Math.Interfaces;
using System.Numerics;

namespace MathC.Console.Services;

public class CalculatorApp<TNumber>(
    IUserInterface userInterface,
    ICalculator<TNumber> calculator,
    IExpressionValidator validator) : ICalculatorApp
    where TNumber : INumber<TNumber>
{
    private readonly IUserInterface _userInterface = userInterface;

    private readonly ICalculator<TNumber> _calculator = calculator;

    private readonly IExpressionValidator _validator = validator;

    public void Run()
    {
        var input = _userInterface.ReadInput("Введите выражение: ");

        try
        {
            if (_validator.IsValid(input) is false)
            {
                _userInterface.WriteOutput($"Неверное выражение.");
                return;
            }

            var result = _calculator.Evaluate(input);

            _userInterface.WriteOutput($"Результат: {result}");
        }
        catch (DivideByZeroException)
        {
            _userInterface.WriteOutput($"Деление на 0 невозможно.");
        }
        catch (Exception)
        {
            //TODO: Logging

            _userInterface.WriteOutput($"Ошибка. Проверьте выражение.");
        }
    }
}
