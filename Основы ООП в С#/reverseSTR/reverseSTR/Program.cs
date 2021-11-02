using System;

namespace reverseSTR
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "qwerty"; 
            string reverse = string.Empty;
            for (int i = str.Length - 1; i > -1; i--)
                reverse += str[i];
            Console.WriteLine(reverse);
        }
    }
}
