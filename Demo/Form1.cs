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
using System.Drawing.Drawing2D;
using Demo.Calculator.Brackets;

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
        }
      
        Calc calc;
        private  void CreateEvents()
        {
            foreach (object item in tableLayoutPanel1.Controls)
            {
                if (!(item is Button)) continue;
                var button = (item as Button);
                button.Click += Clic_k;
                button.Paint += button1_Paint;
                button.BackColor = GetRandomColor();
                button.Refresh();
            }
            Brackers_Info brackers = new Brackers_Info();
            
            
        }
        private void Clic_k(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            var button = sender as Button;
            ColorReset(button);
            if (button.Equals(this.button15)) return;
            if (button.Equals(this.button16)) return;
            this.textBox1.Text += button.Text;
        }
        private void ColorReset(Button button)
        {
            Color color = button.BackColor;
            Task.Run(() =>
            {
                button.BackColor = GetRandomColor();
                Thread.Sleep(200);
                button.BackColor = color;
            });
        }
        private void button16_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }
        readonly Core core = new Core();
        readonly Pars pars = new Pars();
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Text = pars.Start(this.textBox1.Text).ToString();
            }
            catch
            {
                this.textBox1.Text = "Error";
            }
        }
        Regex clear = new Regex("[^0-9+/*,()-]");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = clear.Replace(this.textBox1.Text, "");
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            var button = sender as Button;
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = button.ClientRectangle;
            newRectangle.Inflate(-10, -10);
            e.Graphics.DrawEllipse(Pens.Black, newRectangle);
            newRectangle.Inflate(1, 1);
            buttonPath.AddEllipse(newRectangle);
            button.Region = new Region(buttonPath);
        }
        private Color GetRandomColor()
        {
            return Color.FromArgb(this.random.Next(0, 100), this.random.Next(150, 200), this.random.Next(0, 20));
        }
    }
}
