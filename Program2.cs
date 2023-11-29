using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_test
{
    internal class Program2
    {
        public static void print_hello(object a)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine((string)a+"_Hello World!" + i);
            }
        }
    }
}
