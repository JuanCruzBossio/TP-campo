using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG;

namespace DAL_62_BP
{
    public class BitacoraDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int Alta(RegistroBitacora_62_BP registro)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Bitacora_62_BP (fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP) VALUES (GETDATE(), @dniUsuario, @mensaje, @criticidad)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dniUsuario", registro.DniUsuario),
                new SqlParameter("@mensaje", registro.Mensaje),
                new SqlParameter("@criticidad", registro.Criticidad)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public List<RegistroBitacora_62_BP> ObtenerRegistros()
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            string query = "SELECT id_62_BP, fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP FROM Bitacora_62_BP ORDER BY fecha_62_BP DESC";
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();

                    registro.Id = Convert.ToInt32(fila["id_62_BP"]);
                    registro.Fecha = Convert.ToDateTime(fila["fecha_62_BP"]);
                    registro.DniUsuario = Convert.ToInt32(fila["dniUsuario_62_BP"]);
                    registro.Mensaje = fila["mensaje_62_BP"].ToString();
                    registro.Criticidad = Convert.ToInt32(fila["criticidad_62_BP"]);

                    lista.Add(registro);
                }
            }
            return lista;
        }
    }
}
