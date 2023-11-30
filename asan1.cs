class Program
{
    static void Main(string[] args)
    {
        Thread t1 = new Thread(new ThreadStart(() => thread_test("A", 1000)));
        Thread t2 = new Thread(new ThreadStart(() => thread_test("B", 500)));
        Thread t3 = new Thread(new ThreadStart(() => thread_test("C", 100)));
        t1.Start();
        t2.Start();
        t3.Start();
        Console.WriteLine("Main code is running..!");
        t1.Join();
        t2.Join();
        t3.Join();
        Thread.Sleep(1000);
        Console.WriteLine("Main code end!!");
    }

    static void thread_test(string s, int time)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(time);
            Console.WriteLine(s + "_Thread " + i + " is running...");
        }
    }

}