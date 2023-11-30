namespace ParenthesizedPattern
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            object age = 30;

            if (age is (int and > 19))
                Console.WriteLine("Major");
        }
    }
}