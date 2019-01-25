using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    class Automata
    {
        public void processLine(string line, int index)
        {
            switch (line[index]) 
            {
                case ' ':
                    processSpace(line, index);
                    break;
                case char ch when Char.IsLetter(ch):
                    processLetter(line, index);
                    break;
                case char val when Char.IsDigit(val):
                    processDigit(line, index);
                    break;
                case char ch when Globals.limiters.Contains(ch):
                    processLimiter(line, index);
                    break;
                default:
                    Console.WriteLine("Unknown symbol.");
                    break;
            }
        }

        public void processSpace(string line, int startNum)
        {
            int i = startNum;
            while (line[i] == ' ')
            {
                i++;
            }
            processLine(line, i);
        }

        public void processLetter(string line, int startNum)
        {
            int i = startNum;
            string word = "";
            while ((i < line.Count()) && (Char.IsLetter(line[i]) || Char.IsDigit(line[i]) || (line[i] == '_')))
            {
                word += line[i];
                i++;
            }
            if (Globals.reservedWords.Contains(word))
            {
                Console.WriteLine(word + " - is a key word.");
            }
            else
            {
                Console.WriteLine(word + " - is an identificator.");
            }
            if (i + 1 < line.Count())
            {
                processLine(line, i);
            }
        }

        public void processDigit(string line, int startNum)
        {
            int i = startNum;
            string num = "";
            bool pointWasPut = false;
            bool isInteger = true;
            bool isDouble = false;
            while ((i < line.Count()) && (!Globals.limiters.Contains(line[i]) && (line[i] != ' ')))
            {
                if (Globals.numberSystem.Contains(line[i]))
                {
                    i = checkNum(num, line, i);
                    isInteger = false;
                    break;
                }
                else if (Char.IsLetter(line[i]))
                {
                    Console.WriteLine(num + " - unknown lexeme.");
                    readForNext(line, i);
                    isInteger = false;
                    break;
                }
                if (line[i] == '.')
                {
                    if (!pointWasPut)
                    {
                        pointWasPut = true;
                        num += line[i];
                        isInteger = false;
                        isDouble = true;
                    } 
                    else
                    {
                        Console.WriteLine(num + " - unknown lexeme.");
                        readForNext(line, i);
                        break;
                    }
                }
                num += line[i];
                i++;
            }
            if (isDouble)
            {
                Console.WriteLine(num + " is a double");
            }
            else if (isInteger)
            {
                Console.WriteLine(num + " is an integer");
            }
            if (i + 1 < line.Count())
            {
                processLine(line, i);
            }
        }

        public int checkNum(string num, string line, int startNum)
        {
            int i = startNum;
            if ((num.Count() == 1) && (num[0] == '0'))
            {
                switch (line[i])
                {
                    case 'b':
                        num += line[i];
                        i = readNumSystem(num, line, (startNum + 1), Globals.numSystem.Byte);
                        break;
                    case 'x':
                        num += line[startNum];
                        i = readNumSystem(num, line, (startNum + 1), Globals.numSystem.Hexadecimal);
                        break;
                }
            }
            else
            {
                Console.WriteLine(num + " - unknown lexeme.");
                readForNext(line, startNum);
            }
            return i;
        }

        public int readNumSystem(string num, string line, int startNum, Globals.numSystem numSystem)
        {
            int i = startNum;
            bool isNumber = true;
            while ((i < line.Count()) && (!Globals.limiters.Contains(line[i]) && (line[i] != ' ')))
            {
                bool isDigit = false;
                if (numSystem == Globals.numSystem.Byte)
                {
                    isDigit = Globals.byteNum.Contains(line[i]);
                }
                else
                {
                    isDigit = Char.IsDigit(line[i]);
                }
                if (isDigit || line[i] == '_')
                {
                    num += line[i];
                }
                else
                {
                    Console.WriteLine(num + " - unknown lexeme.");
                    readForNext(line, startNum);
                    isNumber = false;
                    break;
                }
                i++;
            }
            if ((numSystem == Globals.numSystem.Byte) && (isNumber))
            {
                Console.WriteLine(num + " is a byte number.");
            }
            else if (isNumber)
            {
                Console.WriteLine(num + " is a hexadecimal number.");
            }
            return i;
        }

        public void readForNext(string line, int startNum)
        {
            int i = startNum;
            while ((i < line.Count()) && (!Globals.limiters.Contains(line[i]) || (line[i] != ' ')))
            {
                i++;
            }
            if (i + 1 < line.Count())
            {
                processLine(line, i);
            }
        }

        public void processLimiter(string line, int startNum)
        {
            if (startNum + 1 < line.Count())
            {
                processLine(line, startNum +1);
            }
        }

    }
}
