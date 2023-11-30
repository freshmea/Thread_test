using System;

namespace Multiline
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var multiline = """
                별 하나에 추억과
                별 하나에 사랑과
                별 하나에 쓸쓸함과
                별 하나에 동경과
                별 하나에 시와
                별 하나에 어머니, 어머니
                """;

            Console.WriteLine(multiline);
        }
    }
}