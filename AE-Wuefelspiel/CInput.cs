using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_Wuefelspiel
{
    /// <summary>
    /// Eine Klasse zum abgreifen von Userinput aus einer Konsole.
    /// </summary>
    public class CInput
    {
        public static int ReadInt()
        {
            var m_Text = Console.ReadLine();
            if (int.TryParse(m_Text, out var Result))
                return Result;
            else
                throw new FormatException($"Invalid Input Value Provided, expected an Integer, got {m_Text}.");
        }
        public static int ReadInt(string Message)
        {
            Console.Write(Message);
            return ReadInt();
        }
        public static float ReadFloat()
        {
            var m_Text = Console.ReadLine();
            if (float.TryParse(m_Text, out var Result))
                return Result;
            else
                throw new FormatException($"Invalid Input Value Provided, expected a float, got {m_Text}.");
        }
        public static float ReadFloat(string Message)
        {
            Console.Write(Message);
            return ReadFloat();
        }
        public static double ReadDouble()
        {
            var m_Text = Console.ReadLine();
            if (double.TryParse(m_Text, out var Result))
                return Result;
            else
                throw new FormatException($"Invalid Input Value Provided, expected a double, got {m_Text}.");
        }
        public static double ReadDouble(string Message)
        {
            Console.Write(Message);
            return ReadDouble();
        }
        public static string ReadString()
        {
            return Console.ReadLine();
        }
        public static string ReadString(string Message)
        {
            Console.Write(Message);
            return ReadString();
        }
        public static char ReadChar()
        {
            return (char)Console.Read();
        }
        public static char ReadChar(string Message)
        {
            Console.WriteLine(Message);
            return ReadChar();
        }
    }
}
