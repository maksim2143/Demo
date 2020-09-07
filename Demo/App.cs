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
        }
    }
}
