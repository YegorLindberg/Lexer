using System;
using System.Reflection;

namespace Lexer.TokenValue
{
    public static class ExtensionsMethods
    {
        public static string GetStringValue(this Enum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            KeywordAttribute[] attrs = fieldInfo.
                GetCustomAttributes(typeof(KeywordAttribute), false) as KeywordAttribute[];
            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }
    }
}