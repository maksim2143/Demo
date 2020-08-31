﻿using Demo.Calculator;
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
        readonly Random random;
        public Form1()
        {
            this.random = new Random();
            InitializeComponent();
            CreateEvents();
            this.calc = new Calc();
            
            // this.button1.Click += new System.EventHandler(this.button1_Click_1);
        }
      
        Calc calc;
        private void CreateEvents()
        {
            foreach (object item in tableLayoutPanel1.Controls)
            {
                if (!(item is Button)) continue;
                var button = (item as Button);
                button.Click += Click_1;
                button.Paint += button1_Paint;
                button.BackColor = GetRandomColor();
                button.Refresh();
            }
        }
        private void Click_1(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            var button = sender as Button;
            Color color = button.BackColor;
            Task.Run(() =>
            {
                button.BackColor = GetRandomColor();
                Thread.Sleep(200);
                button.BackColor = color;
            });
            if (button.Equals(this.button15)) return;
            if (button.Equals(this.button16)) return;
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
        Regex clear = new Regex("[^0-9+/*,-]");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = clear.Replace(this.textBox1.Text, "");
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            var button = sender as Button;
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
     new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle newRectangle = button.ClientRectangle;
            newRectangle.Inflate(-10, -10);
            e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);
            newRectangle.Inflate(1, 1);
            buttonPath.AddEllipse(newRectangle);
            button.Region = new System.Drawing.Region(buttonPath);
        }
        private Color GetRandomColor()
        {
            return Color.FromArgb(this.random.Next(0, 200), this.random.Next(0, 150), this.random.Next(0, 200));
        }
    }
}
