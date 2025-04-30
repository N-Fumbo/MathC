namespace MathC.Console.Interfaces;

public interface IUserInterface
{
    string ReadInput(string prompt);

    void WriteOutput(string message);
}
