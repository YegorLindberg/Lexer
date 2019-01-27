using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    class Program
    {
        static void Main() //string[] args
        {
            try
            {
                using (StreamReader reader = new StreamReader("../../file.txt"))
                {
                    string line = "";
                    var automata = new Automata();
                    const int startOfLine = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Count() != 0) { automata.ProcessLine(line, startOfLine); }
                        Console.WriteLine(line);
                    }
                    reader.Close();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(err.Message);
            }
        }

    }
}