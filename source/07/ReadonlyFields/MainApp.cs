using System;

namespace ReadonlyFields
{
    class Configuration
    {
        readonly int min;
        readonly int max;

        public Configuration(int v1, int v2)
        {
            min = v1;
            min = v2;
        }

        public void ChangeMax(int newMax)
        {
            max = newMax;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Configuration c = new Configuration(100, 10);
        }
    }
}
