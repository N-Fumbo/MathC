using MathC.Console.Interfaces;

namespace MathC.Console.Services;

public class ConsoleUserInterface : IUserInterface
{
    public string ReadInput(string prompt)
    {
        System.Console.Write(prompt);
        return System.Console.ReadLine() ?? string.Empty;
    }

    public void WriteOutput(string message)
    {
        System.Console.WriteLine(message);
    }
}
