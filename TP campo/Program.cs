using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_62_BP;
using SEG_62_BP;

namespace TP_campo_62_BP
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            try
            {
                IdiomaBLL_62_BP idiomaBLL_62_BP = new IdiomaBLL_62_BP();
                SessionManager_62_BP.GetInstancia_62_BP()
                    .CambiarIdioma_62_BP(idiomaBLL_62_BP.CargarIdioma_62_BP("es-AR"));
            }
            catch
            {

            }

            Application.Run(new Login_62_BP());
        }
    }
}
