namespace PositionalPattern
{
    internal class MainApp
    {
        struct Audience
        {
            public bool IsCitizen { get; init; }
            public int Age { get; init; }            

            public Audience(bool isCitizen, int age)
            {
                IsCitizen = isCitizen;
                Age = age;
            }

            public void Deconstruct(out bool isCitizen, out int age)
            {
                isCitizen = IsCitizen;
                age = Age;
            }
        }

        static void Main(string[] args)
        {
            var CalculateFee = (Audience audience) => audience switch
            {
                (true, < 19) => 100,
                (true, _) => 200,
                (false, < 19) => 200,
                (false, _) => 400,
            };

            var a1 = new Audience(true, 10);
            Console.WriteLine($"내국인: {a1.IsCitizen} 나이: {a1.Age} 요금: {CalculateFee(a1)}");

            var a2 = new Audience(false, 33);
            Console.WriteLine($"내국인: {a2.IsCitizen} 나이: {a2.Age} 요금: {CalculateFee(a2)}");
        }
    }
}