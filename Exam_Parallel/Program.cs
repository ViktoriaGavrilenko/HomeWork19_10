using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int res = 1;
           
            Parallel.For(1, a + 1, (i) =>
            {
                res *= i;
            });

            Console.WriteLine(res);
            Thread.Sleep(2000);
        }
    }
}
