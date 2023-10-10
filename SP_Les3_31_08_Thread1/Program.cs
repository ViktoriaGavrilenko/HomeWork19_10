using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Les3_31_08_Thread1
{
   internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            Thread t = new Thread(MyThreadFunc);
            t.IsBackground = false;
            t.Start();
            Console.WriteLine("End Main");
           // t.Join();
        }

        private static void MyThreadFunc()
        {
            Console.WriteLine("Start Thread");
            Thread.Sleep(20000);
            Console.WriteLine("End Thread");
        }
    }
}
