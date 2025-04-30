namespace MathC.Math;

public static class Tokenizer
{
    /// <summary>
    /// Разбивает строку выражения, на список отдельных токенов
    /// </summary>
    public static List<string> Tokenize(string input)
    {
        //TODO: Добавить поддержку унарных операций
        var tokens = new List<string>();

        var number = string.Empty;

        foreach (char c in input)
        {
            if (char.IsWhiteSpace(c))
                continue;

            if (char.IsDigit(c) || c == '.')
            {
                number += c;
            }
            else
            {
                if (number != string.Empty)
                {
                    tokens.Add(number);
                    number = string.Empty;
                }

                tokens.Add(c.ToString());
            }
        }

        if (number != string.Empty)
            tokens.Add(number);

        return tokens;
    }
}
