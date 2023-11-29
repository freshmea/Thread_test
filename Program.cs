using System;

namespace Thread_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Program2.print_hello));
            t.Start("A");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("A_Hello World!" + i);
            }
            Program2.print_hello("B");
        }
    }
}