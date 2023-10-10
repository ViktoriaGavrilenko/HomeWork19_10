using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample5
{
    class StateObject
    {
        private int state = 5;
        private object sync;

        public void ChangeState(int loop)
        {
            // v2
            lock (sync)
            {
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, "Змагання за розподіленний ресурс виникло після " + loop.ToString() + " циклів");
                }
            }
           
            state = 5;
        }
    }
    public class SampleThread
    {
        public void RaceCondition(object obj)
        {
            StateObject state = obj as StateObject; int i = 0;
            while (true)
            {
                //v1
                
                state.ChangeState(i++);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StateObject R = new StateObject();
            Thread[] threads = new Thread[20];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new SampleThread().RaceCondition);
                threads[i].IsBackground = true;
                threads[i].Start(R);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }
    }
}
