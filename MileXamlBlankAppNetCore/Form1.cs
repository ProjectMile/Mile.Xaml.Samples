using Mile.Xaml;
using System;
using System.Windows.Forms;

namespace MileXamlBlankAppNetCore
{
    public partial class Form1 : Form
    {
        WindowsXamlHost xamlHost = new WindowsXamlHost();

        public Form1()
        {
            InitializeComponent();


            this.Controls.Add(xamlHost);
            xamlHost.AutoSize = true;
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.Child = new MainPage();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
