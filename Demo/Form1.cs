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
            CreateArray();
            CreateEvents();
            this.calc = new Calc();
        
            // this.button1.Click += new System.EventHandler(this.button1_Click_1);
        }
        Calc calc;
        Button[] buttons;
        private void CreateArray()
        {
            buttons = new[]
            {
                this.button1,
                 this.button2,
                  this.button3,
                   this.button4,
                    this.button5,
                     this.button6,
                      this.button7,
                       this.button8,
                       this.button9,
                      this.button10,
                       this.button11,
                       this.button12,
                      this.button13,
                       this.button14,

            };
        }
        private void CreateEvents()
        {
            foreach (Button item in buttons)
            {
                item.Click += Click_1;
            }
        }
        private void Click_1(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
                var button = sender as Button;
            this.textBox1.Text += button.Text;
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
