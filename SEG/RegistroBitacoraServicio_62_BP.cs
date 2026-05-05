using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace SEG
{
    public class RegistroBitacoraServicio_62_BP
    {
        private BitacoraDAL_62_BP _bitacoraDAL = new BitacoraDAL_62_BP();
        public void Alta(string mensaje, int nivelCriticidad)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Fecha = DateTime.Now;
            registro.Mensaje = mensaje;
            registro.Criticidad = nivelCriticidad;

            if (SessionManager_62_BP.GetInstancia().UsuarioLogueado != null)
            {
                registro.IdUsuario = SessionManager_62_BP.GetInstancia().UsuarioLogueado.Id;
            }
            else
            {
                registro.IdUsuario = 0;
            }

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha", registro.Fecha),
                new SqlParameter("@IdUsuario", registro.IdUsuario),
                new SqlParameter("@Mensaje", registro.Mensaje),
                new SqlParameter("@Criticidad", registro.Criticidad)
            };

            _bitacoraDAL.Alta(parametros);
        }
        public List<RegistroBitacora_62_BP> ObtenerBitacora()
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            DataTable tabla = _bitacoraDAL.ObtenerRegistros();

            foreach (DataRow fila in tabla.Rows)
            {
                RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();

                // Mapeamos cada columna al objeto respetando tus propiedades
                registro.Id = Convert.ToInt32(fila["id"]);
                registro.Fecha = Convert.ToDateTime(fila["fecha"]);
                registro.IdUsuario = Convert.ToInt32(fila["idUsuario"]);
                registro.Mensaje = fila["mensaje"].ToString();
                registro.Criticidad = Convert.ToInt32(fila["criticidad"]);

                lista.Add(registro);
            }

            return lista;
        }
    }
}
