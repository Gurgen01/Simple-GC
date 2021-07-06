using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(4000);


            Console.WriteLine("Total memory of Heap in bytes:{0}", GC.GetTotalMemory(false));


            Console.WriteLine("System supports {0} Generations.", (GC.MaxGeneration + 1));
            //Creating car object
            Car car = new Car("Bmw", 180);
            Console.WriteLine(car.ToString());

            Console.WriteLine("Car's generation is {0}", GC.GetGeneration(car));

            Console.WriteLine("Total memory of Heap in bytes:{0}", GC.GetTotalMemory(false));
            //allocate a space in heap
            object[] array = new object[10000000];
            ShowGCstat();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new object();
            }
            Console.WriteLine("Total memory of Heap in bytes:{0}", GC.GetTotalMemory(false));

            array = null;

            Console.WriteLine("GC start");
            var start = DateTime.Now;
            //Free up space with GC
            GC.Collect();

            GC.WaitForPendingFinalizers();
            Console.WriteLine("GC work off  in {0} Milliseconds", (DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine("Total memory of Heap in bytes:{0}", GC.GetTotalMemory(false));
            //As we see car object still exsits
            Console.WriteLine("Car's generation is {0}", GC.GetGeneration(car));
            ShowGCstat();

            Console.ReadKey();
        }
        private static void ShowGCstat()
        {
            Console.WriteLine("Generation 0 was checked {0} times", GC.CollectionCount(0));
            Console.WriteLine("Generation 1 was checked {0} times", GC.CollectionCount(1));
            Console.WriteLine("Generation 2 was checked {0} times", GC.CollectionCount(2));
        }
    }
}