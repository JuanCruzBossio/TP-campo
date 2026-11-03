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
    public class PrestamoMapper_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AgregarPrestamo_62_BP(PrestamoBE_62_BP prestamo)
        {
            string query = "INSERT INTO Prestamo_62_BP (dni_lector_62_BP, fecha_prestamo_62_BP, fecha_limite_62_BP) VALUES (@dniLector, @fechaPrestamo, @fechaLimite);SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros =
            {
                new SqlParameter("@dniLector", prestamo.dni_lector_62_BP),
                new SqlParameter("@fechaPrestamo", prestamo.fecha_prestamo_62_BP),
                new SqlParameter("@fechaLimite", prestamo.fecha_limite_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            return Convert.ToInt32(Convert.ToDecimal(resultado));
        }

        public int ModificarPrestamo_62_BP(PrestamoBE_62_BP prestamo)
        {
            string query = "UPDATE Prestamo_62_BP SET dni_lector_62_BP = @dniLector, fecha_prestamo_62_BP = @fechaPrestamo, fecha_limite_62_BP = @fechaLimite WHERE id_prestamo_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", prestamo.id_prestamo_62_BP),
                new SqlParameter("@dniLector", prestamo.dni_lector_62_BP),
                new SqlParameter("@fechaPrestamo", prestamo.fecha_prestamo_62_BP),
                new SqlParameter("@fechaLimite", prestamo.fecha_limite_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public PrestamoBE_62_BP BuscarPrestamo_62_BP(int? id = null, string dniLector = null)
        {
            StringBuilder query = new StringBuilder("SELECT id_prestamo_62_BP, dni_lector_62_BP, fecha_prestamo_62_BP, fecha_limite_62_BP FROM Prestamo_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND id_prestamo_62_BP = @id");
                parametros.Add(new SqlParameter("@id", id.Value));
            }

            if (!string.IsNullOrEmpty(dniLector))
            {
                query.Append(" AND dni_lector_62_BP = @dniLector");
                parametros.Add(new SqlParameter("@dniLector", dniLector));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new PrestamoBE_62_BP
                {
                    id_prestamo_62_BP = Convert.ToInt32(tabla.Rows[0]["id_prestamo_62_BP"]),
                    dni_lector_62_BP = tabla.Rows[0]["dni_lector_62_BP"].ToString(),
                    fecha_prestamo_62_BP = Convert.ToDateTime(tabla.Rows[0]["fecha_prestamo_62_BP"]),
                    fecha_limite_62_BP = Convert.ToDateTime(tabla.Rows[0]["fecha_limite_62_BP"])
                };
            }

            return null;
        }
    }
}
