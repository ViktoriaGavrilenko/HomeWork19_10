using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Les3_31_08_Thread
{
    public partial class Form1 : Form
    {
        public delegate void MyDel();
        public Form1()
        {
            InitializeComponent();
        }
        public void TestWhile()
        {
            while (true)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDel d1 = TestWhile;
            d1.BeginInvoke(null, null);
            MessageBox.Show("end");
        }
    }
}
