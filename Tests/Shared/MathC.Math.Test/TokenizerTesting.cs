namespace MathC.Math.Test;

public class TokenizerTesting
{
    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_SimpleAddition_ReturnsTokens()
    {
        var input = "2+3";

        var expected = new List<string> { "2", "+", "3" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_ExpressionWithSpaces_ReturnsTokens()
    {
        var input = " 12 +  34 ";

        var expected = new List<string> { "12", "+", "34" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_ExpressionWithParentheses_ReturnsTokens()
    {
        var input = "(2 + 3)";

        var expected = new List<string> { "(", "2", "+", "3", ")" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_ExpressionWithDecimalNumbers_ReturnsTokens()
    {
        var input = "3.14 * 2.0";

        var expected = new List<string> { "3.14", "*", "2.0" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_EmptyString_ReturnsEmptyList()
    {
        var input = "";

        var result = Tokenizer.Tokenize(input);

        Assert.Empty(result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_MultipleOperatorsAndNumbers_ReturnsTokens()
    {
        var input = "10 - 2 * (5 + 1)";

        var expected = new List<string> { "10", "-", "2", "*", "(", "5", "+", "1", ")" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_UnaryMinusAtStart_ShouldBePartOfNumber()
    {
        var input = "-5 + 3";

        var expected = new List<string> { "-5", "+", "3" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_UnaryMinusAfterOperator_ShouldBePartOfNumber()
    {
        var input = "2 * -4";

        var expected = new List<string> { "2", "*", "-4" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    [Trait("Type", "Модульные тесты")]
    public void Tokenize_UnaryMinusInParentheses_ShouldBePartOfNumber()
    {
        var input = "(-3 + 1)";

        var expected = new List<string> { "(", "-3", "+", "1", ")" };

        var result = Tokenizer.Tokenize(input);

        Assert.Equal(expected, result);
    }
}
