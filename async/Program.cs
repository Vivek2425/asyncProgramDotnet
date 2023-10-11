using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async
{
    class Program
    {
       
        static void Main1(string[] args)
        {
            syncClass s = new syncClass();
            Coffee cup = s.PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = s.FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = s.FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = s.ToastBread(2);
            s.ApplyButter(toast);
            s.ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = s.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
            Console.ReadKey();
        }

        static async Task Main2(string[] args)
        {
            asyncClass s = new asyncClass();
            Coffee cup = s.PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = s.FryEggsAsync(2);
            var baconTask = s.FryBaconAsync(3);
            var toastTask = s.MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = s.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
            Console.ReadKey();
        }
      
        static async Task Main(string[] args)
        {
            display("hello world using synchornous programming");
            closeprog("Closing synchornous program");
            asyncdisplay("hello world using asynchornous programming");
            asynccloseprog("Closing asynchornous program");
            Console.ReadKey();
        }
        static void display(string msg)
        {
            Task.Delay(5000).Wait();
            Console.WriteLine(msg);
        }

        static void closeprog(string msg)
        {
            Task.Delay(5000).Wait();
            Console.WriteLine(msg);
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
