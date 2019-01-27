using System;

namespace Lexer.TokenValue
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class SimpleKeywordAttribute : Attribute
    {
        public string Value { get; set; }

        public SimpleKeywordAttribute(string content)
        {
            Value = content;
        }
    }
}