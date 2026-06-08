using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using SEG.Permisos_62_BP;
using SEG_62_BP;

namespace DAL
{
    public class PatenteDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        private Patente_62_BP MapearPatente_62_BP(DataRow fila)
        {
            return new Patente_62_BP
            {
                Id_62_BP = Convert.ToInt32(fila["IdPatente_62_BP"]),
                Nombre_62_BP = fila["Nombre_62_BP"].ToString()
            };
        }

        public Patente_62_BP BuscarPatente_62_BP(int? id = null, string nombre = null)
        {
            StringBuilder query = new StringBuilder(
                "SELECT IdPatente_62_BP, Nombre_62_BP FROM Patente_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND IdPatente_62_BP = @id");
                parametros.Add(new SqlParameter("@id", id.Value));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query.Append(" AND Nombre_62_BP = @nombre");
                parametros.Add(new SqlParameter("@nombre", nombre));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return MapearPatente_62_BP(tabla.Rows[0]);
            }

            return null;
        }

        public List<Patente_62_BP> BuscarPatentes_62_BP()
        {
            List<Patente_62_BP> lista = new List<Patente_62_BP>();

            string query = "SELECT IdPatente_62_BP, Nombre_62_BP FROM Patente_62_BP" ;

           
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearPatente_62_BP(fila));
                }
            }

            return lista;
        }
        public List<Patente_62_BP> BuscarPatentesPorFamilia_62_BP(int idFamilia)
        {
            List<Patente_62_BP> lista = new List<Patente_62_BP>();

            string query = "SELECT P.IdPatente_62_BP, P.Nombre_62_BP FROM Patente_62_BP P INNER JOIN FamiliaPatente_62_BP FP ON P.IdPatente_62_BP = FP.IdPatente_62_BP WHERE FP.IdFamilia_62_BP = @idFamilia";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idFamilia", idFamilia)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearPatente_62_BP(fila));
                }
            }

            return lista;
        }
        public List<Patente_62_BP> BuscarPatentesPorRol_62_BP(int idRol)
        {
            List<Patente_62_BP> lista = new List<Patente_62_BP>();

            string query = "SELECT P.IdPatente_62_BP, P.Nombre_62_BP FROM Patente_62_BP P INNER JOIN RolPatente_62_BP RP ON P.IdPatente_62_BP = RP.IdPatente_62_BP WHERE RP.IdRol_62_BP = @idRol";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idRol", idRol)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearPatente_62_BP(fila));
                }
            }

            return lista;
        }
        public int ActualizarDVH_62_BP(int id, string DVH_62_BP)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Patente_62_BP SET DVH_62_BP = @dvh WHERE IdPatente_62_BP = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@dvh", DVH_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
    }
}
