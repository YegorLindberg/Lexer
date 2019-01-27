namespace Lexer.TokenValue
{
    public enum NumericSystem
    {
        [Keyword("x")] Hexadecimal = 1,
        [Keyword("b")] Byte,
        [Keyword("E")] Exponent
    }

    public enum Keywords
    {
        [Keyword("program")] Program = 4,
        [Keyword("var")] Var,
        [Keyword("let")] Let,
        [Keyword("Char")] Char,
        [Keyword("String")] String,
        [Keyword("Int")] Int,
        [Keyword("Float")] Float,
        [Keyword("Bool")] Bool,
        [Keyword("null")] Null,
        [Keyword("if")] If,
        [Keyword("else")] Else,
        [Keyword("do")] Do,
        [Keyword("while")] While,
        [Keyword("for")] For
    }
    
    
}