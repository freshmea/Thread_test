using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace UsingTask
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string srcFile;
            try
            {
                srcFile = args[0];
            } catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("사용법 : UsingTask.exe <소스파일>");
                return;
            } 
            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state;
                try
                {
                    File.Copy(paths[0], paths[1]);
                }
                catch (FileLoadException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                Console.WriteLine("TaskID:{0}, ThreadID:{1}, {2} was copied to {3}",
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId,
                    paths[0], paths[1]);
            };

            Task t1 = new Task(
                FileCopyAction, 
                new string[]{srcFile, srcFile+".copy1"});

            Task t2 = Task.Run(() => 
            { 
                FileCopyAction(new string[] { srcFile, srcFile + ".copy2" }); 
            });
            
            t1.Start();

            Task t3 = new Task(
                FileCopyAction, 
                new string[] { srcFile, srcFile + ".copy3" });

            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();


            var myTask = Task<List<int>>.Run(
                () =>
                {
                    Thread.Sleep(1000);

                    List<int> list = new List<int>();
                    list.Add(3);
                    list.Add(4);
                    list.Add(5);

                    return list;
                }
            );

            myTask.Wait();

        }
    }
}
