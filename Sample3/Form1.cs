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

namespace Sample3
{
    public partial class Form1 : Form
    {
        int counter; public delegate void MyDel();
        public Form1()
        {
            InitializeComponent();
        }
        public void TestWhile()
        {
            while (true)
            {
                this.Text = counter++.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(TestWhile);
            t.IsBackground = true; 
           // t.IsBackground = false; 
            t.Start();
            MessageBox.Show("End");
        }
    }


}
