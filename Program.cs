#region

using System;
using System.Windows.Forms;

#endregion

namespace EmergencyBrake
{
    internal static class Program
    {
        private static Form form1;

        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }

        /// <summary> Use this when exiting the application. </summary>
        public static void ExitApplication()
        {
            Application.Exit();
        }
    }
}