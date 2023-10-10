using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Exam
{
    public partial class Form1 : Form
    {
        //private readonly object lockObject = new object();
        private int[] numbers;
        //private int generatedCount = 0;
       private ManualResetEvent generationComplete = new ManualResetEvent(false);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numbers = new int[1000];
            //generatedCount = 0;

            Thread generatorThread = new Thread(GenerateNumbers);
            generatorThread.Start();
           // generationComplete.WaitOne();

            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread avgThread = new Thread(FindCalculateAverage);
            maxThread.Start();
            minThread.Start();
            avgThread.Start();
        }
        private void GenerateNumbers()
        {
            Random random = new Random();
            for(int i = 0; i < numbers.Length; i++)
            {
                
                    numbers[i] = random.Next(0, 5001);
                this.Invoke((MethodInvoker)delegate
                {
                    textBox1.AppendText(numbers[i].ToString() + Environment.NewLine);
                });    
                
                Thread.Sleep(25);
            }

            generationComplete.Set();

        }
        private void FindMax()
        {
            generationComplete.WaitOne();
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text = max.ToString();
            });
        }
        private void FindMin()
        {
            generationComplete.WaitOne();
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                textBox3.Text = min.ToString();
            });
        }
        private void FindCalculateAverage()
        {
            generationComplete.WaitOne();
            int sum = 0;
                for(int i = 0; i < numbers.Length; i++)
                {
                    sum += numbers[i];
                }
                double average = (double)sum / numbers.Length;
            this.Invoke((MethodInvoker)delegate
            {
                textBox4.Text = average.ToString();
            });
        }
    }
}
