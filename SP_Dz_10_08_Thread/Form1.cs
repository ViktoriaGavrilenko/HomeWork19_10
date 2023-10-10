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

namespace SP_Dz_10_08_Thread
{
    public partial class Form1 : Form
    {
        private bool generating = false;
        private Thread numberThread;
        private Thread letterThread;
        private Thread symbolThread;
        private ComboBox comboBoxNumbers;
        private ComboBox comboBoxLetters;
        private ComboBox comboBoxSymbols;
        private int numbersCount = 0;
        private int lettersCount = 0;
        private int symbolsCount = 0;
        public Form1()
        {
            InitializeComponent();
            comboBoxNumbers = comboBox1;
            comboBoxLetters = comboBox2;
            comboBoxSymbols = comboBox3;
            comboBoxNumbers.Items.Add(ThreadPriority.Lowest);
            comboBoxNumbers.Items.Add(ThreadPriority.BelowNormal);
            comboBoxNumbers.Items.Add(ThreadPriority.Normal);
            comboBoxNumbers.Items.Add(ThreadPriority.AboveNormal);
            comboBoxNumbers.Items.Add(ThreadPriority.Highest);
           
            comboBoxLetters.Items.Add(ThreadPriority.Lowest);
            comboBoxLetters.Items.Add(ThreadPriority.BelowNormal);
            comboBoxLetters.Items.Add(ThreadPriority.Normal);
            comboBoxLetters.Items.Add(ThreadPriority.AboveNormal);
            comboBoxLetters.Items.Add(ThreadPriority.Highest);

            comboBoxSymbols.Items.Add(ThreadPriority.Lowest);
            comboBoxSymbols.Items.Add(ThreadPriority.BelowNormal);
            comboBoxSymbols.Items.Add(ThreadPriority.Normal);
            comboBoxSymbols.Items.Add(ThreadPriority.AboveNormal);
            comboBoxSymbols.Items.Add(ThreadPriority.Highest);
        }
        private void btn_generate_Click(object sender, EventArgs e)
        {
            generating = true;
            numbersCount = 0;
            lettersCount = 0;
            symbolsCount = 0;
            numberThread = new Thread(() => GenerateNumbers(textBoxNumbers, textBox4));
            letterThread = new Thread(() => GenerateLetters(textBoxLetters, textBox5));
            symbolThread = new Thread(() => GenerateSymbols(textBoxSymbols, textBox6));
            numberThread.Start();
            letterThread.Start();
            symbolThread.Start();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (comboBoxNumbers.SelectedIndex != -1)
            {
                ThreadPriority selectedPriority = (ThreadPriority)comboBoxNumbers.SelectedItem;
                numberThread.Priority = selectedPriority;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLetters.SelectedIndex != -1)
            {
                ThreadPriority selectedPriority = (ThreadPriority)comboBoxLetters.SelectedItem;
                letterThread.Priority = selectedPriority;
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSymbols.SelectedIndex != -1)
            {
                ThreadPriority selectedPriority = (ThreadPriority)comboBoxSymbols.SelectedItem;
                symbolThread.Priority = selectedPriority;
            }
        }
        private void GenerateNumbers(TextBox textBox, TextBox countTextBox)
        {
            Random random = new Random();
            while (generating)
            {
                int number = random.Next(10);
                textBox.Invoke(new Action(() => textBox.Text += random.Next(10).ToString()));
                Interlocked.Increment(ref numbersCount);
                countTextBox.Invoke(new Action(() => countTextBox.Text = numbersCount.ToString()));
                Thread.Sleep(25);
            }
        }
        private void GenerateLetters(TextBox textBox, TextBox countTextBox)
        {
            Random random = new Random();
            string letters = "abcdefghijklmnoprstuvwxyz";
            while (generating)
            {
                char letter = letters[random.Next(letters.Length)];
                textBox.Invoke(new Action(() => textBox.Text += letters[random.Next(letters.Length)]));
                Interlocked.Increment(ref lettersCount);
                countTextBox.Invoke(new Action(() => countTextBox.Text = lettersCount.ToString()));
                Thread.Sleep(25);
            }
        }
        private void GenerateSymbols(TextBox textBox, TextBox countTextBox)
        {
            Random random = new Random();
            string symbols = "!@#$%^&*()";
            while (generating)
            {
                char symbol = symbols[random.Next(symbols.Length)];
                textBox.Invoke(new Action(() => textBox.Text += symbols[random.Next(symbols.Length)]));
                Interlocked.Increment(ref symbolsCount);
                countTextBox.Invoke(new Action(() => countTextBox.Text = symbolsCount.ToString()));
                Thread.Sleep(25);
            }
        }
    }
}
