using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //static void Main()
        //{
        //    Action<object> action = (object obj) =>
        //    {
        //        Console.WriteLine("Task={0}, obj={1}, Thread={2}",
        //        Task.CurrentId, obj,
        //        Thread.CurrentThread.ManagedThreadId);
        //    };

        //    // Create a task but do not start it.
        //    Task t1 = new Task(action, "alpha");

        //    // Construct a started task
        //    Task t2 = Task.Factory.StartNew(action, "beta");
        //    // Block the main thread to demonstate that t2 is executing
        //    t2.Wait();

        //    // Launch t1 
        //    t1.Start();
        //    Console.WriteLine("t1 has been launched. (Main Thread={0})",
        //                      Thread.CurrentThread.ManagedThreadId);
        //    // Wait for the task to finish.
        //    t1.Wait();

        //    // Construct a started task using Task.Run.
        //    String taskData = "delta";
        //    Task t3 = Task.Run(() => {
        //        Console.WriteLine("Task={0}, obj={1}, Thread={2}",
        //                          Task.CurrentId, taskData,
        //                           Thread.CurrentThread.ManagedThreadId);
        //    });
        //    // Wait for the task to finish.
        //    t3.Wait();

        //    // Construct an unstarted task
        //    Task t4 = new Task(action, "gamma");
        //    // Run it synchronously
        //    t4.RunSynchronously();
        //    // Although the task was run synchronously, it is a good practice
        //    // to wait for it in the event exceptions were thrown by the task.
        //    t4.Wait();
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {

            Console.WriteLine(string.Format("Main task is running.. ThreadId is: {0}.", Thread.CurrentThread.ManagedThreadId));
            Task.Run(() =>
            {
                Task1();
            });
            
            Console.WriteLine("(Let's assume at here) Main thread exits..");
            
            Console.ReadKey();
        }

        static async Task Task1()
        {
            Console.WriteLine("New task1 is running.. ThreadId is: {0}.", Thread.CurrentThread.ManagedThreadId);
            Task t2 = Task2();

            Console.WriteLine("New task1 is doing some independent work..");
            Console.WriteLine("New task1 is sleeping now..");
            Thread.Sleep(5000);
            Console.WriteLine("New task1 finished sleeping..");
            await t2;
            //Console.WriteLine("The value returned by Task2 is:" + num);
            Console.WriteLine("New task1 exits..");
        }

        static async Task Task2()
        {
            Console.WriteLine("New task2 is running.. ThreadId is: {0}.", Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(2000);
            //throw new NotSupportedException();
            Console.WriteLine("New task2 exits..");
        }

        //static async Task Task1()
        //{
        //    Console.WriteLine("New task1 is running.. ThreadId is: {0}.", Thread.CurrentThread.ManagedThreadId);

        //    Task t2 = Task2();
        //    //t2.Start();
        //    //throw new NotSupportedException();
        //    Thread.Sleep(1000);
        //    Console.WriteLine("New task1 is doing some independent work..");
        //    await t2;
        //    //Console.WriteLine("The value returned by Task2 is:" + num);
        //    Console.WriteLine("New task1 exits..");
        //}

        //static Task Task2()
        //{
        //    return Task.Run(() =>
        //    {
        //        Console.WriteLine("New task2 is running.. ThreadId is: {0}.", Thread.CurrentThread.ManagedThreadId);
        //        Thread.Sleep(2000);
        //        //throw new NotSupportedException();
        //        Console.WriteLine("New task2 exits..");
        //    });


        //}
    }
}
