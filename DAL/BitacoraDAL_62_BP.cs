using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG_62_BP;

namespace DAL_62_BP
{
    public class BitacoraDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AltaBitacora_62_BP(RegistroBitacora_62_BP registro)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Bitacora_62_BP (fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP) VALUES (GETDATE(), @dniUsuario, @mensaje, @criticidad)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dniUsuario", registro.DniUsuario_62_BP),
                new SqlParameter("@mensaje", registro.Mensaje_62_BP),
                new SqlParameter("@criticidad", registro.Criticidad_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public List<RegistroBitacora_62_BP> ObtenerRegistros_62_BP()
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            string query = "SELECT id_62_BP, fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP FROM Bitacora_62_BP ORDER BY fecha_62_BP DESC";
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();

                    registro.Id_62_BP = Convert.ToInt32(fila["id_62_BP"]);
                    registro.Fecha_62_BP = Convert.ToDateTime(fila["fecha_62_BP"]);
                    registro.DniUsuario_62_BP = fila["dniUsuario_62_BP"].ToString();
                    registro.Mensaje_62_BP = fila["mensaje_62_BP"].ToString();
                    registro.Criticidad_62_BP = Convert.ToInt32(fila["criticidad_62_BP"]);

                    lista.Add(registro);
                }
            }
            return lista;
        }
    }
}
