namespace Lexer.TokenValue
{
    public enum NumericSystem
    {
        [Keyword("x")] Hexadecimal = 1,
        [Keyword("b")] Byte,
        [Keyword("o")] Octal,
        [Keyword("E")] WithExponent
    }

    public enum Keywords
    {
        Identificator = 4,
        [Keyword("program")] Program,
        [Keyword("var")] Var,
        [Keyword("let")] Let,
        [Keyword("Int")] Int,
        [Keyword("Double")] Double,
        [Keyword("null")] Null,
        [Keyword("if")] If,
        [Keyword("else")] Else,
        [Keyword("do")] Do,
        [Keyword("while")] While,
        [Keyword("for")] For
    }
    
    public enum MainLimiters
    {
        [SimpleToken(".")] Dot,
        [SimpleToken(",")] Comma,
        [SimpleToken(";")] Semicolon
    }

    public enum Limiters
    {
        [SimpleToken("[")] LeftBracket,
        [SimpleToken("]")] RightBracket,

        [SimpleToken("{")] LeftBrace,
        [SimpleToken("}")] RightBrace,

        [SimpleToken("(")] LeftParenthesis,
        [SimpleToken(")")] RightParenthesis,
        
        [SimpleToken(">")] Greater,
        [SimpleToken("<")] Less,
        [SimpleToken("+")] Plus,
        [SimpleToken("-")] Minus,
        [SimpleToken("=")] Assignment,
        [SimpleToken("!")] Not,
        [SimpleToken("*")] Multiply,
        [SimpleToken("/")] Divide,
        [SimpleToken("%")] Mod,
        
        [SimpleToken(">=")] GreaterOrEqual,
        [SimpleToken("<=")] LessOrEqual,
        [SimpleToken("==")] Equal,
        [SimpleToken("!=")] NotEqual
    }
    
}