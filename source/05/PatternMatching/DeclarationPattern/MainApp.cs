namespace DeclarationPattern
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            int? foo = 23;

            if (foo is int bar)
            {
                Console.WriteLine(bar);
            }
        }
    }
}