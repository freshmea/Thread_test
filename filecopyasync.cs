using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncFileIO
{
    class MainApp
    {
        // 파일 복사 후 복사한 파일 용량 반환.
        static async Task<long> CopyAsync(string FromPath, string ToPath)
        {
            using (
                var fromStream = new FileStream(FromPath, FileMode.Open))
            {
                long totalCopied = 0;

                using (
                    var toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int nRead = 0;
                    while ((nRead =
                        await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;
                    }
                }

                return totalCopied;
            }
        }

        static async void DoCopy(string FromPath, string ToPath)
        {
            long totalCopied = await CopyAsync(FromPath, ToPath);
            Console.WriteLine($"Copied Total {totalCopied} Bytes.");
        }

        static void Main(string[] args)
        {
            int args_len = args.Length;
            if (args.Length < 2)
            {
                Console.WriteLine("Usage : AsyncFileIO <Source> <Destination>");
                return;
            }
            for (int i = 0; i < args_len / 2; i++)
            {
                Console.WriteLine(i);
                DoCopy(args[i * 2], args[i * 2 + 1]);
            }

            Console.ReadLine();
        }
    }
}
