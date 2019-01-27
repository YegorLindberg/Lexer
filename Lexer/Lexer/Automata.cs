using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexer.TokenValue;

namespace Lexer
{
    public class Automata
    {
        public void ProcessLine(string line, int index)
        {
            switch (line[index])
            {
                case ' ':
                    ProcessSpace(line, index);
                    break;
                case char ch when Char.IsLetter(ch):                    
                    ProcessLetter(line, index);
                    break;
                case char val when Char.IsDigit(val):
                    ProcessDigit(line, index);
                    break;
                case char ch when Global.limiters.Contains(ch):
                    ProcessLimiter(line, index);
                    break;
                default:
                    Console.WriteLine("Unknown symbol.");
                    break;
            }
        }

        private void ProcessSpace(string line, int index)
        {            
            int i = index;
            bool wasProcessing = false;
            while ((i < line.Count()) && (line[i] == ' '))
            {
                if (!wasProcessing) { wasProcessing = true; }
                Console.Write("space ");
                i++;
            }
            if ((i < line.Count()) && wasProcessing) { ProcessLine(line, i); }
        }

        private void ProcessLetter(string line, int index)
        {
            int i = index;
            string word = "";
            bool wasProcessing = false;
            while ((i < line.Count())
                   && ((line[i] != Global.space) || !Global.limiters.Contains(line[i])))
            {
                if (!wasProcessing) { wasProcessing = true; }
                word += line[i].ToString();
                i++;
            }
            if (Global.reservedWords.Contains(word)) { Console.WriteLine("keyword: " + word); }
            else { Console.WriteLine("ID " + word); }
            if ((i < line.Count()) && wasProcessing) { ProcessLine(line, i); }
        }

        private void ProcessDigit(string line, int index)
        {
            int i = index;
            string number = "";
            bool isInteger = true;
            bool wasProcessing = false;
            while ((i < line.Count()) 
                   && ((line[i] != Global.space) && !Global.limiters.Contains(line[i]))
                   && isInteger)
            {
                switch (line[i])
                {
                    case char ch when (Char.IsLetter(ch)):
                        isInteger = false;
                        DetermineNumericSystem(line, i, number);
                        break;
                    case char ch when (Char.IsDigit(ch)):
                        number += ch.ToString();
                        break;
                    case char ch when (ch == '.'):
                        isInteger = false;
                        ProcessDouble(line, i, number);
                        break;
                    default:
                        var answer = ReadToLimiter(line, i, number);
                        i = answer.Item2;
                        Console.WriteLine("Error in number: " + answer.Item1);
                        isInteger = false;
                        break;
                }
                if (!wasProcessing) { wasProcessing = true; }
                number += line[i].ToString();
                i++;
            }
            if (isInteger) { Console.WriteLine("id: NUM, val: " + number); }
            if ((i < line.Count()) && wasProcessing && isInteger) { ProcessLine(line, i); }
        }

        private void ProcessDouble(string line, int index, string number)
        {
            int i = index;
            number += line[i].ToString();
            i++;
            bool isDouble = true;
            while ((i < line.Count())
                   && ((line[i] != Global.space) || Global.limiters.Contains(line[i]))
                   && isDouble)
            {
                switch (line[i])
                {
                    case char ch when (Char.IsDigit(ch)):
                        number += ch.ToString();
                        break;
                    default:
                        var answer = ReadToLimiter(line, i, number);
                        i = answer.Item2;
                        Console.WriteLine("Error in double: " + answer.Item1);
                        isDouble = false;
                        break;
                }
            }
            if ((number[number.Length] != '.') && (isDouble))
            {
                Console.WriteLine("Id: " + "Double" + "; val:" + number);
            }
            if ((i < line.Count())) { ProcessLine(line, i); }
        }
        
        private void DetermineNumericSystem(string line, int index, string number)
        {
            switch (line[index].ToString())
            {
                case string str when (str == NumericSystem.Hexadecimal.GetStringValue()):
                    Console.WriteLine("ID: Hexadecimal"); //TODO: Func to Hexadecimal.
                    break;
                case string str when (str == NumericSystem.Byte.GetStringValue()):
                    Console.WriteLine("ID: Byte"); //TODO: Func to Byte.
                    break;
                case string str when (str == NumericSystem.Exponent.GetStringValue()):
                    Console.WriteLine("ID: Exponent"); //TODO: Func to Exponent.
                    break;
                default:
                    Console.WriteLine("Number error.");
                    break;
            }

            double a = 1.23;
        }

        private Tuple<string, int> ReadToLimiter(string line, int index, string value)
        {
            int i = index;
            string val = value;
            while ((i < line.Count())
                   && ((line[i] != Global.space) || !Global.limiters.Contains(line[i])))
            {
                val += line[i].ToString();
                i++;
            }
            var pair = new Tuple<string, int>(val, i);
            return pair;
        }
        

        private void ProcessLimiter(string line, int index)
        {
            int i = index;
            var a = 000123;
            Console.WriteLine(a);
            if (i + 1 < line.Count()) { ProcessLine(line, i + 1); }
        }
        
        
    }
}