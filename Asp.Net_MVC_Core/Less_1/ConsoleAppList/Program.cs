using System;
using System.Threading;

namespace ConsoleAppList
{
    class Program
    {
        static void Main(string[] args)
        {
            var classlist = new ClassList<string>();
            var threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var thread_id = Environment.CurrentManagedThreadId;
                    for (int j = 0; j < 100; j++)
                    {
                        classlist.Add($"Значение: {j} в потоке номер: {thread_id}");
                    }
                });
                threads[i].Start();
            }
        }
    }
}
