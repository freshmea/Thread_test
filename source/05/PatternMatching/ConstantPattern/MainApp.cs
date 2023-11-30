using System.Reflection.PortableExecutable;

namespace ConstantPattern
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            var GetCountryCode = (string nation) => nation switch
            {
                "KR" => 82,
                "US" => 1,
                "UK" => 44,
                _ => throw new ArgumentException("Not supported Code")
            };

            Console.WriteLine(GetCountryCode("KR"));
            Console.WriteLine(GetCountryCode("US"));
            Console.WriteLine(GetCountryCode("UK"));
        }
    }
}
