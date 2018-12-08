using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timestamper
{
    static class timestamper
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.option_startminized)
            {
                mainwindow timestamper = new mainwindow();
                Application.Run();
            } else
            {
                Application.Run(new mainwindow());
            }
        }
    }
}
