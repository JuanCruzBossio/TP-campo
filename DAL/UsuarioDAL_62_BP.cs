using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SEG.Permisos_62_BP;
using SEG_62_BP;
namespace DAL_62_BP
{
    public class UsuarioDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();
        private Usuario_62_BP MapearUsuario(DataRow fila)
        {
            return new Usuario_62_BP
            {
                Dni_62_BP = fila["dni_62_BP"].ToString(),
                Apellido_62_BP = fila["apellido_62_BP"].ToString(),
                Nombre_62_BP = fila["nombre_62_BP"].ToString(),
                IdRol_62_BP = Convert.ToInt16(fila["idRol_62_BP"].ToString()),
                Email_62_BP = fila["email_62_BP"].ToString(),
                Login_62_BP = fila["login_62_BP"].ToString(),
                Contrasena_62_BP = fila["contrasena_62_BP"].ToString(),
                Bloqueo_62_BP = Convert.ToBoolean(fila["bloqueo_62_BP"]),
                Activo_62_BP = Convert.ToBoolean(fila["activo_62_BP"]),
                IntentosLogin_62_BP = Convert.ToInt16(fila["intentosLogin_62_BP"]),
                ForzarContrasenaNueva_62_BP = Convert.ToBoolean(fila["ForzarContrasenaNueva_62_BP"])
            };
        }
        public Usuario_62_BP BuscarUsuario_62_BP(string dni = null, string login = null, string contrasena = null, int? idRol = null)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM Usuario_62_BP WHERE 1=1");
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(dni))
            {
                query.Append(" AND dni_62_BP = @dni");
                parametros.Add(new SqlParameter("@dni", dni));
            }
            if (!string.IsNullOrEmpty(login))
            {
                query.Append(" AND login_62_BP = @login");
                parametros.Add(new SqlParameter("@login", login));
            }
            if (!string.IsNullOrEmpty(contrasena))
            {
                query.Append(" AND contrasena_62_BP = @contrasena");
                parametros.Add(new SqlParameter("@contrasena", contrasena));
            }
            if (idRol != null)
            {
                query.Append(" AND idRol = @idRol");
                parametros.Add(new SqlParameter("@idRol", idRol));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return MapearUsuario(tabla.Rows[0]);
            }
            return null;
        }
        public List<Usuario_62_BP> BuscarUsuarios_62_BP(string dni = null, string login = null, string contrasena = null, int? idRol = null)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM Usuario_62_BP WHERE 1=1");
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Usuario_62_BP> lista = new List<Usuario_62_BP>();
            
            if (!string.IsNullOrEmpty(dni))
            {
                query.Append(" AND dni_62_BP = @dni");
                parametros.Add(new SqlParameter("@dni", dni));
            }
            if (!string.IsNullOrEmpty(login))
            {
                query.Append(" AND login_62_BP = @login");
                parametros.Add(new SqlParameter("@login", login));
            }
            if (!string.IsNullOrEmpty(contrasena))
            {
                query.Append(" AND contrasena_62_BP = @contrasena");
                parametros.Add(new SqlParameter("@contrasena", contrasena));
            }
            if (idRol != null)
            {
                query.Append(" AND idRol = @idRol");
                parametros.Add(new SqlParameter("@idRol", idRol));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearUsuario(fila));
                }
            }
            return lista;
        }
        public List<Usuario_62_BP> TraerTodosUsuarios_62_BP()
        {
            List<Usuario_62_BP> lista = new List<Usuario_62_BP>();
            string query = "SELECT *  FROM Usuario_62_BP";

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearUsuario(fila));
                }
            }
            return lista;
        }

        public int Alta_62_BP(Usuario_62_BP usuario)
        {
            var dni = 0;
            string query = "INSERT INTO Usuario_62_BP (dni_62_BP, apellido_62_BP, nombre_62_BP, idrol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP) VALUES (@dni, @apellido, @nombre, @idRol, @email, @login, @contrasena, 0, 1);SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@apellido", usuario.Apellido_62_BP),
                new SqlParameter("@nombre", usuario.Nombre_62_BP),
                new SqlParameter("@idRol", usuario.IdRol_62_BP),
                new SqlParameter("@email", usuario.Email_62_BP),
                new SqlParameter("@login", usuario.Login_62_BP),
                new SqlParameter("@contrasena", usuario.Contrasena_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            dni = Convert.ToInt32(Convert.ToDecimal(resultado));
            return dni;
        }
        public int Activar_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET activo_62_BP = 1 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public int Desactivar_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET activo_62_BP = 0 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Modificar_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET apellido_62_BP = @apellido, nombre_62_BP = @nombre, idrol_62_BP = @idRol, email_62_BP = @email, login_62_BP = @login WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@apellido", usuario.Apellido_62_BP),
                new SqlParameter("@nombre", usuario.Nombre_62_BP),
                new SqlParameter("@idRol", usuario.IdRol_62_BP),
                new SqlParameter("@email", usuario.Email_62_BP),
                new SqlParameter("@login", usuario.Login_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Bloquear_62_BP(string login)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET bloqueo_62_BP = 1,  ForzarContrasenaNueva_62_BP = 1 WHERE login_62_BP = @login";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@login", login)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Desbloquear_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET bloqueo_62_BP = 0 , contrasena_62_BP = @contrasena , intentosLogin_62_BP = 0 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@contrasena", usuario.Contrasena_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int CambiarContrasena_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET contrasena_62_BP = @contrasena, ForzarContrasenaNueva_62_BP = 0 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@contrasena", usuario.Contrasena_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int GuardarIntentosLogin_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET intentosLogin_62_BP = @intentos WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@intentos", usuario.IntentosLogin_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public int ActualizarDVH_62_BP(string dni, string DVH_62_BP)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET DVH_62_BP = @dvh WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", dni),
                new SqlParameter("@dvh", DVH_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public string BuscarDVH_62_BP(string dni)
        {
            var dvh = "";
            string query = "SELECT *  FROM Usuario_62_BP WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", dni)
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
