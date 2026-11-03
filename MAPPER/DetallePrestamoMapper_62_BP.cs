using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using BE_62_BP;

namespace MAPPER_62_BP
{
    public class DetallePrestamoMapper_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public bool AgregarDetallePrestamo_62_BP(DetallePrestamoBE_62_BP detallePrestamo)
        {
            string query = "INSERT INTO DetallePrestamo_62_BP (id_libro_62_BP, id_prestamo_62_BP, devuelto_62_BP, perdido_62_BP) VALUES (@idLibro, @idPrestamo, @devuelto, @perdido);";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idLibro", detallePrestamo.id_libro_62_BP),
                new SqlParameter("@idPrestamo", detallePrestamo.id_prestamo_62_BP),
                new SqlParameter("@devuelto", detallePrestamo.devuelto_62_BP),
                new SqlParameter("@perdido", detallePrestamo.perdido_62_BP)
            };

            int filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas > 0;
        }

        public bool ModificarDetallePrestamo_62_BP(DetallePrestamoBE_62_BP detallePrestamo)
        {
            string query = "UPDATE DetallePrestamo_62_BP SET id_libro_62_BP = @idLibro, id_prestamo_62_BP = @idPrestamo, devuelto_62_BP = @devuelto, perdido_62_BP = @perdido WHERE id_libro_62_BP = @idLibro AND id_prestamo_62_BP = @idPrestamo";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idLibro", detallePrestamo.id_libro_62_BP),
                new SqlParameter("@idPrestamo", detallePrestamo.id_prestamo_62_BP),
                new SqlParameter("@devuelto", detallePrestamo.devuelto_62_BP),
                new SqlParameter("@perdido", detallePrestamo.perdido_62_BP)
            };

            int filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas > 0;
        }

        public DetallePrestamoBE_62_BP BuscarDetallePrestamo_62_BP(int idLibro = 0, int idPrestamo = 0)
        {
            StringBuilder query = new StringBuilder("SELECT id_libro_62_BP, id_prestamo_62_BP, devuelto_62_BP, perdido_62_BP FROM DetallePrestamo_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (idLibro > 0)
            {
                query.Append(" AND id_libro_62_BP = @idLibro");
                parametros.Add(new SqlParameter("@idLibro", idLibro));
            }

            if (idPrestamo > 0)
            {
                query.Append(" AND id_prestamo_62_BP = @idPrestamo");
                parametros.Add(new SqlParameter("@idPrestamo", idPrestamo));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new DetallePrestamoBE_62_BP
                {
                    id_libro_62_BP = Convert.ToInt32(tabla.Rows[0]["id_libro_62_BP"]),
                    id_prestamo_62_BP = Convert.ToInt32(tabla.Rows[0]["id_prestamo_62_BP"]),
                    devuelto_62_BP = Convert.ToBoolean(tabla.Rows[0]["devuelto_62_BP"]),
                    perdido_62_BP = Convert.ToBoolean(tabla.Rows[0]["perdido_62_BP"])
                };
            }

            return null;
        }
    }
}
