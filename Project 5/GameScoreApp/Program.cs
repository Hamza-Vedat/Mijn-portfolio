using System;
using System.Windows.Forms;
using GameScoreApp.Views;

namespace GameScoreApp
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());  // StartForm starten
        }
    }
}