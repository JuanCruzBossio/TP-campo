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
    public class RolDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        private Rol_62_BP MapearRol_62_BP(DataRow fila)
        {
            return new Rol_62_BP
            {
                Id_62_BP = Convert.ToInt32(fila["IdRol_62_BP"]),
                Nombre_62_BP = fila["Nombre_62_BP"].ToString()
            };
        }

        public int Alta_62_BP(Rol_62_BP rol)
        {
            int id = 0;
            string query = "INSERT INTO Rol_62_BP (Nombre_62_BP) VALUES (@nombre);SELECT SCOPE_IDENTITY();";
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", rol.Nombre_62_BP)
            };
            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            id = Convert.ToInt32(Convert.ToDecimal(resultado));
            return id;
        }

        public int Modificar_62_BP(Rol_62_BP rol)
        {
            string query = "UPDATE Rol_62_BP SET Nombre_62_BP = @nombre WHERE IdRol_62_BP = @id";

            SqlParameter[] parametros =
            {
            new SqlParameter("@id", rol.Id_62_BP),
            new SqlParameter("@nombre", rol.Nombre_62_BP)
        };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int Baja_62_BP(int idRol)
        {
            string query = "DELETE FROM Rol_62_BP WHERE IdRol_62_BP = @id";

            SqlParameter[] parametros =
            {
            new SqlParameter("@id", idRol)
        };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public Rol_62_BP BuscarRol_62_BP(int? id = null, string nombre = null)
        {
            StringBuilder query = new StringBuilder("SELECT IdRol_62_BP, Nombre_62_BP FROM Rol_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND IdRol_62_BP = @id");
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
                return MapearRol_62_BP(tabla.Rows[0]);
            }

            return null;
        }

        public List<Rol_62_BP> BuscarRoles_62_BP()
        {
            List<Rol_62_BP> lista = new List<Rol_62_BP>();

            string query = "SELECT IdRol_62_BP, Nombre_62_BP FROM Rol_62_BP ORDER BY Nombre_62_BP";

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearRol_62_BP(fila));
                }
            }

            return lista;
        }

        public int AgregarPatente_62_BP(int idRol, int idPatente)
        {
            string query = "INSERT INTO RolPatente_62_BP (IdRol_62_BP, IdPatente_62_BP) VALUES (@idRol, @idPatente)";

            SqlParameter[] parametros =
            {
            new SqlParameter("@idRol", idRol),
            new SqlParameter("@idPatente", idPatente)
        };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int QuitarPatente_62_BP(int idRol, int idPatente)
        {
            string query = "DELETE FROM RolPatente_62_BP WHERE IdRol_62_BP = @idRol AND IdPatente_62_BP = @idPatente";

            SqlParameter[] parametros =
            {
            new SqlParameter("@idRol", idRol),
            new SqlParameter("@idPatente", idPatente)
        };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int AgregarFamilia_62_BP(int idRol, int idFamilia)
        {
            string query = "INSERT INTO RolFamilia_62_BP (IdRol_62_BP, IdFamilia_62_BP) VALUES (@idRol, @idFamilia)";

            SqlParameter[] parametros =
            {
            new SqlParameter("@idRol", idRol),
            new SqlParameter("@idFamilia", idFamilia)
        };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int QuitarFamilia_62_BP(int idRol, int idFamilia)
        {
            string query = "DELETE FROM RolFamilia_62_BP WHERE IdRol_62_BP = @idRol AND IdFamilia_62_BP = @idFamilia";

            SqlParameter[] parametros =
            {
            new SqlParameter("@idRol", idRol),
            new SqlParameter("@idFamilia", idFamilia)
        };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }
        public int BorrarRelacionesRolFamilia_62_BP(int idRol)
        {
            string query = "DELETE FROM RolFamilia_62_BP WHERE IdRol_62_BP = @idRol";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idRol", idRol),
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }
        public int BorrarRelacionesRolPatente_62_BP(int idRol)
        {
            string query = "DELETE FROM RolPatente_62_BP WHERE IdRol_62_BP = @idRol";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idRol", idRol),
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }
        public bool TieneUsuariosAsignados_62_BP(int idRol)
        {
            string query = "SELECT IdRol_62_BP FROM Usuario_62_BP where IdRol_62_BP = @idRol";
            SqlParameter[] parametros =
            {
                new SqlParameter("@idRol", idRol),
            };
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        public int ActualizarDVH_62_BP(int id, string DVH_62_BP)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Rol_62_BP SET DVH_62_BP = @dvh WHERE IdRol_62_BP = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@dvh", DVH_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public string BuscarDVH_62_BP(int id)
        {
            var dvh = "";
            string query = "SELECT *  FROM Rol_62_BP WHERE IdRol_62_BP = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla != null && tabla.Rows.Count > 0)
            {
                dvh = tabla.Rows[0]["DVH_62_BP"].ToString();
            }
            return dvh;
        }
    }
}
