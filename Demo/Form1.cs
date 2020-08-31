using Demo.Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.random = new Random();
            CreateEvents();
            this.calc = new Calc();
            // this.button1.Click += new System.EventHandler(this.button1_Click_1);
        }
        Calc calc;
        private void CreateEvents()
        {
            this.button1.Click += Click_1;
            this.button2.Click += Click_1;
            this.button3.Click += Click_1;
            this.button4.Click += Click_1;
            this.button5.Click += Click_1;
            this.button6.Click += Click_1;
            this.button7.Click += Click_1;
            this.button8.Click += Click_1;
            this.button9.Click += Click_1;
            this.button10.Click += Click_1;
            this.button11.Click += Click_1;
            this.button12.Click += Click_1;
            this.button13.Click += Click_1;
            this.button14.Click += Click_1;

        }
        private void Click_1(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
                var button = sender as Button;
            this.textBox1.Text += button.Text;
        }
        Random random;
        private string Get()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 1; i++)
            {
                list.Add(this.random.Next(0, 1000));
            }
            var result = string.Join("", list.Select(x => x.ToString()).ToArray());
            Thread.Sleep(1000);
            return result;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var result = await Task.Run(() => Get());
                list.Add(result);
            }
            this.textBox1.Text = string.Join("|\n", list.ToArray());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }
        readonly Core core = new Core();
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Text = core.Start(this.textBox1.Text).ToString();
            }
            catch
            {
                this.textBox1.Text = "Error";
            }
        }
        Regex clear = new Regex("[^0-9+/*-]");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = clear.Replace(this.textBox1.Text, "");
        }
    }
}
