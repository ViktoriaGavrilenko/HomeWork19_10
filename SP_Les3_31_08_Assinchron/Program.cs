using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Les3_31_08_Assinchron
{
    internal class Program
    {
        public delegate int MyDel(int a, int b); 
        static int Add(int a, int b)
        {
            Console.WriteLine("Start Add");
            Thread.Sleep(2000); 
            Console.WriteLine("End Add");
            return a + b;
        }
        static void MyCallBack(IAsyncResult ar)
        {
            MyDel d = ar.AsyncState as MyDel;
            int result = d.EndInvoke(ar); 
            Console.WriteLine(result.ToString());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            MyDel d1 = Add; 
            d1.BeginInvoke(1, 2, MyCallBack, d1);
            Console.ReadLine();
            Console.WriteLine("End Main");
        }
    }
}
