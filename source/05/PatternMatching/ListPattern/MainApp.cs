namespace ListPattern
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            var GetStatistics = (List<object[]> records) =>
            {
                var statistics = new Dictionary<string, int>();

                foreach (var record in records)
                {
                    var (contentType, contentViews) = record switch
                    {
                        [_, "COMEDY", .., var views] => ("COMEDY", views),
                        [_, "SF", .., var views] => ("SF", views),
                        [_, "ACTION", .., var views] => ("ACTION", views),
                        [_, .., var amount] => ("ETC", amount),
                        _ => ("ETC", 0),
                    };

                    if( statistics.ContainsKey(contentType))
                        statistics[contentType] += (int)contentViews;
                    else
                        statistics.Add(contentType, (int)contentViews);
                }

                return statistics;
            };

            List<object[]> MovieRecords = new List<object[]>()
            {
                new object[] { 0, "COMEDY", "Spy", 2015, 10_000 },
                new object[] { 1, "COMEDY", "Scary Movie", 20_000 },
                new object[] { 2, "SF", "Avengers: Inifinte War", 100_000 },
                new object[] { 3, "COMEDY", "극한직업", 25_000 },
                new object[] { 4, "SF", "Star Wars: A New Hope", 200_000 },
                new object[] { 5, "ACTION", "Fast & Furious", 80_000 },
                new object[] { 6, "DRAMA", "Notting Hill", 1_000 },
            };

            var statistics = GetStatistics(MovieRecords);

            foreach(var s in statistics)
                Console.WriteLine($"{s.Key}: {s.Value}");            
        }
    }
}