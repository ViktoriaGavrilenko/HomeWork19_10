using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadLockSample
{
    public class Data
    {
        public int Id { get; set; }
    }
    public class SampleCondition
    {
        Data R1;
        Data R2;
        public SampleCondition(Data r1, Data r2)
        {
            R1 = r1;
            R2 = r2;
        }
        public void deadlock1()
        {
            lock (R1)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Start deadlock1");
                lock (R2)
                {

                }
                Console.WriteLine("End deadlock1");
            }
        }
        public void deadlock2()
        {
            lock (R2)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Start deadlock2");
                lock (R1)
                {
                    
                }
                Console.WriteLine("End deadlock2");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Data R1 = new Data();
            Data R2 = new Data();
            new Thread
        }
    }
}
