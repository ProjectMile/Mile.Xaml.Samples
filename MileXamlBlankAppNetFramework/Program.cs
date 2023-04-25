using MileXamlBlankAppNetFramework;
using System;
using System.Windows.Forms;

namespace MileXamlBlankAppNetFrameworkModern
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            App app = new();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            app.Close();
        }
    }
}
