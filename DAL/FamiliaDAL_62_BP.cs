using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using SEG.Permisos_62_BP;

namespace DAL
{
    public class FamiliaDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        private Familia_62_BP MapearFamilia_62_BP(DataRow fila)
        {
            return new Familia_62_BP
            {
                Id_62_BP = Convert.ToInt32(fila["IdFamilia_62_BP"]),
                Nombre_62_BP = fila["Nombre_62_BP"].ToString()
            };
        }

        public int Alta_62_BP(Familia_62_BP familia)
        {
            string query = "INSERT INTO Familia_62_BP (Nombre_62_BP) VALUES (@nombre)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", familia.Nombre_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int Modificar_62_BP(Familia_62_BP familia)
        {
            string query = "UPDATE Familia_62_BP SET Nombre_62_BP = @nombre WHERE IdFamilia_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", familia.Id_62_BP),
                new SqlParameter("@nombre", familia.Nombre_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int Baja_62_BP(int idFamilia)
        {
            string query = "DELETE FROM Familia_62_BP WHERE IdFamilia_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", idFamilia)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public Familia_62_BP BuscarFamilia_62_BP(int? id = null, string nombre = null)
        {
            StringBuilder query = new StringBuilder("SELECT IdFamilia_62_BP, Nombre_62_BP FROM Familia_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND IdFamilia_62_BP = @id");
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
                return MapearFamilia_62_BP(tabla.Rows[0]);
            }

            return null;
        }

        public List<Familia_62_BP> BuscarFamilias_62_BP()
        {
            List<Familia_62_BP> lista = new List<Familia_62_BP>();

            string query = "SELECT IdFamilia_62_BP, Nombre_62_BP FROM Familia_62_BP ORDER BY Nombre_62_BP";

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearFamilia_62_BP(fila));
                }
            }

            return lista;
        }

        public int AgregarPatente_62_BP(int idFamilia, int idPatente)
        {
            string query = "INSERT INTO FamiliaPatente_62_BP (IdFamilia_62_BP, IdPatente_62_BP) VALUES (@idFamilia, @idPatente)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idFamilia", idFamilia),
                new SqlParameter("@idPatente", idPatente)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int QuitarPatente_62_BP(int idFamilia, int idPatente)
        {
            string query = "DELETE FROM FamiliaPatente_62_BP WHERE IdFamilia_62_BP = @idFamilia AND IdPatente_62_BP = @idPatente";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idFamilia", idFamilia),
                new SqlParameter("@idPatente", idPatente)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int AgregarFamilia_62_BP(int idFamiliaPadre, int idFamiliaHija)
        {
            string query = "INSERT INTO FamiliaFamilia_62_BP (IdFamiliaPadre_62_BP, IdFamiliaHija_62_BP) VALUES (@padre, @hija)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@padre", idFamiliaPadre),
                new SqlParameter("@hija", idFamiliaHija)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int QuitarFamilia_62_BP(int idFamiliaPadre, int idFamiliaHija)
        {
            string query = "DELETE FROM FamiliaFamilia_62_BP WHERE IdFamiliaPadre_62_BP = @padre AND IdFamiliaHija_62_BP = @hija";

            SqlParameter[] parametros =
            {
                new SqlParameter("@padre", idFamiliaPadre),
                new SqlParameter("@hija", idFamiliaHija)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public List<Familia_62_BP> BuscarFamiliasPorFamilia_62_BP(int idFamilia)
        {
            List<Familia_62_BP> lista = new List<Familia_62_BP>();

            string query = "SELECT F.IdFamilia_62_BP, F.Nombre_62_BP FROM Familia_62_BP F INNER JOIN FamiliaFamilia_62_BP FF ON F.IdFamilia_62_BP = FF.IdFamiliaHija_62_BP WHERE FF.IdFamiliaPadre_62_BP = @idFamilia";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idFamilia", idFamilia)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearFamilia_62_BP(fila));
                }
            }

            return lista;
        }
        public List<Familia_62_BP> BuscarFamiliasPorRol_62_BP(int idRol)
        {
            List<Familia_62_BP> lista = new List<Familia_62_BP>();

            string query = "SELECT F.IdFamilia_62_BP, F.Nombre_62_BP FROM Familia_62_BP F INNER JOIN RolFamilia_62_BP RF ON F.IdFamilia_62_BP = RF.IdFamilia_62_BP WHERE RF.IdRol_62_BP = @idRol";
            SqlParameter[] parametros =
            {
                new SqlParameter("@idRol", idRol)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearFamilia_62_BP(fila));
                }
            }

            return lista;
        }
    }
}