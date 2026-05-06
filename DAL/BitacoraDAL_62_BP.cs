using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG;

namespace DAL
{
    public class BitacoraDAL_62_BP
    {
        private Acceso_62_BP _acceso = new Acceso_62_BP();

        public int Alta(RegistroBitacora_62_BP registro)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Bitacora (fecha, idUsuario, mensaje, criticidad) VALUES (@Fecha, @IdUsuario, @Mensaje, @Criticidad)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha", registro.Fecha),
                new SqlParameter("@IdUsuario", registro.IdUsuario),
                new SqlParameter("@Mensaje", registro.Mensaje),
                new SqlParameter("@Criticidad", registro.Criticidad)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public List<RegistroBitacora_62_BP> ObtenerRegistros()
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            string query = "SELECT id, fecha, idUsuario, mensaje, criticidad FROM Bitacora ORDER BY fecha DESC";
            DataTable tabla = _acceso.leer(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();

                    registro.Id = Convert.ToInt32(fila["id"]);
                    registro.Fecha = Convert.ToDateTime(fila["fecha"]);
                    registro.IdUsuario = Convert.ToInt32(fila["idUsuario"]);
                    registro.Mensaje = fila["mensaje"].ToString();
                    registro.Criticidad = Convert.ToInt32(fila["criticidad"]);

                    lista.Add(registro);
                }
            }
            return lista;
        }
    }
}
