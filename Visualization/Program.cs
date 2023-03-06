using System;
using System.Windows.Forms;

namespace SteeringCS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WorldForm worldForm = new WorldForm();
            Application.Run(new MultiFormContext(worldForm, new DebugForm(worldForm)));
        }
    }
}
