using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo
{
    class App:Application
    {
        public void InitializeComponent()
        {
            this.StartupUri = new System.Uri("UserControl1.xaml", System.UriKind.Relative);
            var form = Task.Run(() =>
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new Form1());
            });
        }
    }
}
