namespace TypePattern
{
    class Preschooler { }
    class Underage { }
    class Adult  { }
    class Senior { }

    internal class MainApp
    {
        static int CalculateFee(object visitor)
        {
            return visitor switch
            {
                Underage => 100,
                Adult => 500,
                Senior => 200,
                _ => throw new ArgumentException($"Prohibited age: {visitor.GetType()}", nameof(visitor)),
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Fee for a senior: {CalculateFee(new Senior())}");
            Console.WriteLine($"Fee for a adult: {CalculateFee(new Adult())}");
            Console.WriteLine($"Fee for a underage: {CalculateFee(new Underage())}");
            Console.WriteLine($"Fee for a preschooler: {CalculateFee(new Preschooler())}");
        }
    }
}