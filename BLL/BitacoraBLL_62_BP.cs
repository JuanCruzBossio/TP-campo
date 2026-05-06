using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEG;

namespace BLL
{
    public class BitacoraBLL_62_BP
    {
        private BitacoraDAL_62_BP _bitacoraDAL = new BitacoraDAL_62_BP();

        public void Alta(string mensaje, int nivelCriticidad)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Mensaje = mensaje;
            registro.Criticidad = nivelCriticidad;

            if (SessionManager_62_BP.GetInstancia().UsuarioLogueado != null)
            {
                registro.DniUsuario = Convert.ToInt32(SessionManager_62_BP.GetInstancia().UsuarioLogueado.Dni);
            }
            else
            {
                registro.DniUsuario = 0;
            }

            _bitacoraDAL.Alta(registro);
        }
        public List<RegistroBitacora_62_BP> ObtenerBitacora()
        {
            return _bitacoraDAL.ObtenerRegistros();
        }
    }
}
