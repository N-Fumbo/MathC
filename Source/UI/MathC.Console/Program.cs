using MathC.Console.Services;
using MathC.Math.Services;
using MathC.Math.Services.Calculators;
using MathC.Math.Services.Converters;
using MathC.Math.Services.Evaluators;
using MathC.Math.Services.Operation;
using System.Globalization;

//TODO: Написать тесты на MathC.Console

//TODO: Внедрить механизм внедрения зависимостей

CultureInfo culture = CultureInfo.InvariantCulture;

OperationFactory<double> operationFactory = new();

/* TODO: 
 Фабрику можно собирать через механизм внедрение зависмостей.
 Пример:
  Получить IEnumerable<IOperation> operations
  
  В цикле пройтись по operations и добавить в фабрику

 Это позволит немодернезировать текущий код. 
 А для добавление новой операции, достаточно будет просто создать новый класс.
 */

operationFactory.Register(new AddOperation<double>());

operationFactory.Register(new DivideOperation<double>());

operationFactory.Register(new MultiplyOperation<double>());

operationFactory.Register(new SubtractOperation<double>());


RpnConverter<double> converter = new(operationFactory, culture);

RpnEvaluator<double> evaluator = new(operationFactory, culture);

RpnCalculator<double> rpnCalculator = new(converter, evaluator);

ConsoleUserInterface consoleUserInterface = new();

SimpleExpressionValidator validator = new();

CalculatorApp<double> app = new(consoleUserInterface, rpnCalculator, validator);


while(true)
{
    app.Run();
}