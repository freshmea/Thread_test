namespace RelationalPattern
{
    internal class MainApp
    {
        static string GetGrade(double score) => score switch
        {
            < 60 => "F",
            >= 60 and < 70 => "D",
            >= 70 and < 80 => "C",
            >= 80 and < 90 => "B",
            _ => "A",
        };

        static void Main(string[] args)
        {
            Console.WriteLine(GetGrade(99));
            Console.WriteLine(GetGrade(67));
            Console.WriteLine(GetGrade(57));
        }
    }
}