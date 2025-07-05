using Mile.Xaml;
using System;
using System.Windows.Forms;

namespace MileXamlControlsDemoNetFramework
{
    public partial class Form1 : Form
    {
        private readonly WindowsXamlHost xamlHost = new();

        public Form1()
        {
            InitializeComponent();

            this.Controls.Add(xamlHost);
            xamlHost.AutoSize = true;
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.Child = new MainPage();

            this.Load += Form1_Load;

            //ContainerControl control = new ContainerControl();
            //this.Controls.Add(control);
            //control.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
