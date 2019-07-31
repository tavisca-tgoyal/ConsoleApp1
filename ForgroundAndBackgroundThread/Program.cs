using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ForgroundAndBackgroundThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main thread start");
            Thread t1 = new Thread(() => Fun1());
            t1.Start();

            Thread t2 = new Thread(() => Fun2());
            t2.Start();

            Console.WriteLine("main thread ends");          

        }

        private static void Fun2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("fun1");
                Thread.Sleep(1000);
            }
        }

        private static void Fun1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("fun2");
                Thread.Sleep(1000);
            }
        }
    }
}
