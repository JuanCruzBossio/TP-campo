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
    public class LectorMapper_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AgregarLector_62_BP(LectorBE_62_BP lector)
        {
            string query = "INSERT INTO Lector_62_BP (dni_62_BP, nombre_62_BP, apellido_62_BP, fecha_nacimiento_62_BP) VALUES (@dni, @nombre, @apellido, @fecha_nacimiento);";

            SqlParameter[] parametros =
            {
                new SqlParameter("@dni", lector.dni_62_BP),
                new SqlParameter("@nombre", lector.nombre_62_BP),
                new SqlParameter("@apellido", lector.apellido_62_BP),
                new SqlParameter("@fecha_nacimiento", lector.fecha_nacimiento_62_BP ?? (object)DBNull.Value)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int ModificarLector_62_BP(LectorBE_62_BP lector)
        {
            string query = "UPDATE Lector_62_BP SET nombre_62_BP = @nombre, apellido_62_BP = @apellido, fecha_nacimiento_62_BP = @fecha_nacimiento WHERE dni_62_BP = @dni";

            SqlParameter[] parametros =
            {
                new SqlParameter("@dni", lector.dni_62_BP),
                new SqlParameter("@nombre", lector.nombre_62_BP),
                new SqlParameter("@apellido", lector.apellido_62_BP),
                new SqlParameter("@fecha_nacimiento", lector.fecha_nacimiento_62_BP ?? (object)DBNull.Value)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public LectorBE_62_BP BuscarLector_62_BP(string dni = null, string nombre = null)
        {
            StringBuilder query = new StringBuilder("SELECT dni_62_BP, nombre_62_BP, apellido_62_BP, fecha_nacimiento_62_BP FROM Lector_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(dni))
            {
                query.Append(" AND dni_62_BP = @dni");
                parametros.Add(new SqlParameter("@dni", dni));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query.Append(" AND nombre_62_BP = @nombre");
                parametros.Add(new SqlParameter("@nombre", nombre));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new LectorBE_62_BP
                {
                    dni_62_BP = tabla.Rows[0]["dni_62_BP"].ToString(),
                    nombre_62_BP = tabla.Rows[0]["nombre_62_BP"].ToString(),
                    apellido_62_BP = tabla.Rows[0]["apellido_62_BP"].ToString(),
                    fecha_nacimiento_62_BP = tabla.Rows[0]["fecha_nacimiento_62_BP"] as DateTime?
                };
            }

            return null;
        }

        public List<LectorBE_62_BP> BuscarLectores_62_BP()
        {
            string query = "SELECT dni_62_BP, nombre_62_BP, apellido_62_BP, fecha_nacimiento_62_BP FROM Lector_62_BP ORDER BY dni_62_BP";
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);
            List<LectorBE_62_BP> lectores = new List<LectorBE_62_BP>();

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lectores.Add(new LectorBE_62_BP
                    {
                        dni_62_BP = fila["dni_62_BP"].ToString(),
                        nombre_62_BP = fila["nombre_62_BP"].ToString(),
                        apellido_62_BP = fila["apellido_62_BP"].ToString(),
                        fecha_nacimiento_62_BP = fila["fecha_nacimiento_62_BP"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(fila["fecha_nacimiento_62_BP"])
                    });
                }
            }

            return lectores;
        }

        public int ActualizarDVH_62_BP(string dni, string dvh)
        {
            string query = "UPDATE Lector_62_BP SET DVH_62_BP = @dvh WHERE dni_62_BP = @dni";
            SqlParameter[] parametros =
            {
                new SqlParameter("@dni", dni),
                new SqlParameter("@dvh", dvh)
            };
            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public string BuscarDVH_62_BP(string dni)
        {
            string query = "SELECT DVH_62_BP FROM Lector_62_BP WHERE dni_62_BP = @dni";
            SqlParameter[] parametros = { new SqlParameter("@dni", dni) };
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);
            return tabla != null && tabla.Rows.Count > 0
                ? tabla.Rows[0]["DVH_62_BP"].ToString()
                : string.Empty;
        }
    }
}
