using System;

namespace Thread_test
{
    class Program
    {
        static void print_hello_with_f_no_parameter()
        {
            Program2.print_hello("F");
        }
        static void thread_test()
        {
            Console.WriteLine("Emty thread!");
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Program2.print_hello));
            Thread th;
            Thread th2;
            Thread th3;
            ParameterizedThreadStart ts;
            ThreadStart ts2;
            ts = new ParameterizedThreadStart(Program2.print_hello);
            ts += new ParameterizedThreadStart(Program2.print_hello);
            ts2 = new ThreadStart(() => Program2.print_hello("D"));
            ts2 += new ThreadStart(() => Program2.print_hello("E"));
            th = new Thread(ts);
            th2 = new Thread(ts2);
            Thread t2 = new Thread(new ParameterizedThreadStart(Program2.print_hello));
            t1.Start("A");
            t2.Start("B");
            th.Start("C");
            th2.Start();
            // th3 = new Thread(print_hello_with_f_no_parameter);
            th3 = new Thread(() => Program2.print_hello("F"));
            Thread th4 = new Thread(thread_test);
            th3.Start();
            th4.Start();
            t1.Join();
            t2.Join();
            th.Join();
            th2.Join();
            th3.Join();
            th4.Join();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");

        }
    }
}