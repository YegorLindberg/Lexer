namespace Lexer.TokenValue
{
    public class Global
    {
        public static char space = ' ';

        public static char[] numberSystems =
        {
            'x',
            'b',
            'E'
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
            "Char",
            "String",
            "Int",
            "Float",
            "Bool",
            "null",
            "if",
            "else",
            "do",
            "while",
            "for"
        };
    }
}