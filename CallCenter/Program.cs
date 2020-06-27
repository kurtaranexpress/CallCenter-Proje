using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCenter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(new login());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //CallCenterEntities veri = new CallCenterEntities();
            //var kayit = (from p in veri.KULLANICILAR_TBL where p.KUL_ID  == AnaForm.userid select p).SingleOrDefault();
            //kayit.KUL_ADI  = kayit.KUL_ADI + "x";
            //veri.SaveChanges();
        }
    }
}
