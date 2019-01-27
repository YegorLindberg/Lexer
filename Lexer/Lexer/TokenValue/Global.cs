namespace Lexer.TokenValue
{
    public class Global
    {
        public static char whiteSpace = ' ';
        public static char separator = '_';

        public static char[] byteDigit =
        {
            '0',
            '1'
        };

        public static char[] mainLimiters =
        {
            ',',
            '.',
            ';'
        };
        
        public static char[] limiters = 
        {
            '(',
            ')',
            '[',
            ']',
            ':',
            '+',
            '-',
            '*',
            '/',
            '<',
            '>',
            '@',
            '!',
            '='
        };
        
        public static string[] reservedWords = 
        {
            "program",
            "var",
            "let",
            "Int",
            "Double",
            "null",
            "if",
            "else",
            "do",
            "while",
            "for"
        };
    }
}