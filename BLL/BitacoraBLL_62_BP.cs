using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using SEG_62_BP;

namespace BLL_62_BP
{
    public class BitacoraBLL_62_BP
    {
        private BitacoraDAL_62_BP _bitacoraDAL = new BitacoraDAL_62_BP();

        public void AltaBitacora_62_BP(string mensaje, int nivelCriticidad)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Mensaje_62_BP = mensaje;
            registro.Criticidad_62_BP = nivelCriticidad;

            if (SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP != null)
            {
                registro.DniUsuario_62_BP = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Dni_62_BP;
            }
            else
            {
                registro.DniUsuario_62_BP = "0";
            }

            _bitacoraDAL.AltaBitacora_62_BP(registro);
        }
        public void AltaBitacora_62_BP(string mensaje, int nivelCriticidad, string dni)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Mensaje_62_BP = mensaje;
            registro.Criticidad_62_BP = nivelCriticidad;
            registro.DniUsuario_62_BP = dni;

            _bitacoraDAL.AltaBitacora_62_BP(registro);
        }
        public List<RegistroBitacora_62_BP> ObtenerBitacora_62_BP()
        {
            return _bitacoraDAL.ObtenerRegistros_62_BP();
        }
    }
}
