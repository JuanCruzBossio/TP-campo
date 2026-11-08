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
    public class SolicitudInsatisfechaMapper_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AgregarSolicitudInsatisfecha_62_BP(SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha)
        {
            string query = "INSERT INTO SolicitudInsatisfecha_62_BP (id_libro_62_BP, dni_lector_62_BP, fecha_62_BP) VALUES (@idLibro, @dniLector, @fecha);SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idLibro", solicitudInsatisfecha.id_libro_62_BP),
                new SqlParameter("@dniLector", solicitudInsatisfecha.dni_lector_62_BP),
                new SqlParameter("@fecha", solicitudInsatisfecha.fecha_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            return Convert.ToInt32(Convert.ToDecimal(resultado));
        }

        public int ModificarSolicitudInsatisfecha_62_BP(SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha)
        {
            string query = "UPDATE SolicitudInsatisfecha_62_BP SET id_libro_62_BP = @idLibro, dni_lector_62_BP = @dniLector, fecha_62_BP = @fecha WHERE id_solicitud_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", solicitudInsatisfecha.id_solicitud_62_BP),
                new SqlParameter("@idLibro", solicitudInsatisfecha.id_libro_62_BP),
                new SqlParameter("@dniLector", solicitudInsatisfecha.dni_lector_62_BP),
                new SqlParameter("@fecha", solicitudInsatisfecha.fecha_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public SolicitudInsatisfechaBE_62_BP BuscarSolicitudInsatisfecha_62_BP(int? id = null, int idLibro = 0, string dniLector = null)
        {
            StringBuilder query = new StringBuilder("SELECT id_solicitud_62_BP, id_libro_62_BP, dni_lector_62_BP, fecha_62_BP FROM SolicitudInsatisfecha_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND id_solicitud_62_BP = @id");
                parametros.Add(new SqlParameter("@id", id.Value));
            }

            if (idLibro > 0)
            {
                query.Append(" AND id_libro_62_BP = @idLibro");
                parametros.Add(new SqlParameter("@idLibro", idLibro));
            }

            if (!string.IsNullOrWhiteSpace(dniLector))
            {
                query.Append(" AND dni_lector_62_BP = @dniLector");
                parametros.Add(new SqlParameter("@dniLector", dniLector));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new SolicitudInsatisfechaBE_62_BP
                {
                    id_solicitud_62_BP = Convert.ToInt32(tabla.Rows[0]["id_solicitud_62_BP"]),
                    id_libro_62_BP = Convert.ToInt32(tabla.Rows[0]["id_libro_62_BP"]),
                    dni_lector_62_BP = tabla.Rows[0]["dni_lector_62_BP"].ToString(),
                    fecha_62_BP = Convert.ToDateTime(tabla.Rows[0]["fecha_62_BP"])
                };
            }

            return null;
        }
    }
}
