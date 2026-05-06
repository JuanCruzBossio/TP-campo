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
            string query = "INSERT INTO Bitacora (fecha, dniUsuario, mensaje, criticidad) VALUES (GETDATE(), @dniUsuario, @mensaje, @criticidad)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dniUsuario", registro.DniUsuario),
                new SqlParameter("@mensaje", registro.Mensaje),
                new SqlParameter("@criticidad", registro.Criticidad)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public List<RegistroBitacora_62_BP> ObtenerRegistros()
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            string query = "SELECT id, fecha, dniUsuario, mensaje, criticidad FROM Bitacora ORDER BY fecha DESC";
            DataTable tabla = _acceso.leer(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();

                    registro.Id = Convert.ToInt32(fila["id"]);
                    registro.Fecha = Convert.ToDateTime(fila["fecha"]);
                    registro.DniUsuario = Convert.ToInt32(fila["dniUsuario"]);
                    registro.Mensaje = fila["mensaje"].ToString();
                    registro.Criticidad = Convert.ToInt32(fila["criticidad"]);

                    lista.Add(registro);
                }
            }
            return lista;
        }
    }
}
