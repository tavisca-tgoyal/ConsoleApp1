using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        static int _noOfElements = 100;
        static int[] arr = new int[_noOfElements];
        static int noOfPortions = 5;
        static int portionSize = _noOfElements / noOfPortions;
        static void Main(string[] args)
        {
            
            FillArray();

            //normal addition
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine(GetSum());
            stopWatch.Stop();
            Console.WriteLine("normal addition of array takes" + stopWatch.Elapsed + " time");

            //addition via multithreading using divide and conquor
            stopWatch.Reset();
            stopWatch.Start();
            var value = GetSumUsingMultiThreading();
            Console.WriteLine(value);
            stopWatch.Stop();
            Console.WriteLine("addition via multithreading takes:" + stopWatch.Elapsed + " time");


            Console.Read();
        }

        private static long GetSumUsingMultiThreading()
        {
            long sum = 0;
            
            //declaring array that will store the intermediate result
            var interArray = new long[noOfPortions];
            //getting sum of each portion and storing the result in the interArray
            Thread[] threads = new Thread[noOfPortions];
            for (int i = 0; i < noOfPortions; i++)
            {
                

                threads[i] = new Thread(
                                        () => { interArray[i] = GetSumOfThePortion(i); }
                                       );
                threads[i].Start();


            }

            for (int i = 0; i < noOfPortions; i++)
            {
                threads[i].Start();
            }


            for (int i = 0; i < noOfPortions; i++)
            {
                threads[i].Join();
            }

            //getting the total sum
            for (int i = 0; i < noOfPortions; i++)
            {
                sum += interArray[i];
            }
            return sum;
        }

        private static long GetSumOfThePortion(int portionumber)
        {
            int sum = 0;
            
            int startingIndex = portionumber * portionSize;
            for (int i = startingIndex; i < startingIndex + portionSize; i++)
            {
                sum += arr[i];
            }
            return sum;
        }        

        private static long GetSum()
        {
            long sum =0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        private static void FillArray()
        {
            var rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1;
            }
        }
    }
}
