using System;
using System.Threading.Tasks;

namespace CoreAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            asyncdisplay("hello world using asynchornous programming");
            asynccloseprog("Closing asynchornous program");
            Console.ReadKey();
        }
        static async Task asyncdisplay(string msg)
        {
            Console.WriteLine("Async task display starts");
            await Task.Delay(8000);
            Console.WriteLine(msg);
        }
        static async Task asynccloseprog(string msg)
        {
            Console.WriteLine("Async task close starts");
            await Task.Delay(3000);
            Console.WriteLine(msg);

        }
    }
}
