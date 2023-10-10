using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolSample
{
    internal class Program
    {
        static void MyThreadFunc(object obj)
        {
            string data = obj as string; 
            Thread.Sleep(2000);
            Console.WriteLine(data);
        }
        static void Main(string[] args)
        {
            int a = 0; int b = 0; 
            ThreadPool.GetMaxThreads(out a, out b);
            Console.WriteLine(a.ToString()); 
            Console.WriteLine(b.ToString());

            string name = "Hello"; 
            ThreadPool.QueueUserWorkItem(MyThreadFunc, name);
            Console.ReadKey();
        }
    }

}
