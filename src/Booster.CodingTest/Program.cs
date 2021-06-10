using System;

namespace Booster.CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            while(stream.CanRead)
            {
                int b = stream.ReadByte();
                Console.WriteLine(Convert.ToChar(b));
            }
        }
    }
}
