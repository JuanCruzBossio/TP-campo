using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BitacoraDAL_62_BP
    {
        private Acceso_62_BP _acceso = new Acceso_62_BP();

        public int Alta(SqlParameter[] parametros)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Bitacora (fecha, idUsuario, mensaje, criticidad) VALUES (@Fecha, @IdUsuario, @Mensaje, @Criticidad)";

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public DataTable ObtenerRegistros()
        {
            string query = "SELECT id, fecha, idUsuario, mensaje, criticidad FROM Bitacora ORDER BY fecha DESC";
            DataTable tabla = _acceso.leer(query, null);
            return tabla;
        }
    }
}
