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
    public class UsuarioDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();
        public List<Usuario_62_BP> TraerTodosUsuarios_62_BP()
        {
            List<Usuario_62_BP> lista = new List<Usuario_62_BP>();
            string query = "SELECT dni_62_BP, apellido_62_BP, nombre_62_BP, rol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP FROM Usuario_62_BP";

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Usuario_62_BP usuario = new Usuario_62_BP();

                    usuario.Dni_62_BP = fila["dni_62_BP"].ToString();
                    usuario.Apellido_62_BP = fila["apellido_62_BP"].ToString();
                    usuario.Nombre_62_BP = fila["nombre_62_BP"].ToString();
                    usuario.Rol_62_BP = fila["rol_62_BP"].ToString();
                    usuario.Email_62_BP = fila["email_62_BP"].ToString();
                    usuario.Login_62_BP = fila["login_62_BP"].ToString();
                    usuario.Contrasena_62_BP = fila["contrasena_62_BP"].ToString();
                    usuario.Bloqueo_62_BP = Convert.ToBoolean(fila["bloqueo_62_BP"]);
                    usuario.Activo_62_BP = Convert.ToBoolean(fila["activo_62_BP"]);

                    lista.Add(usuario);
                }
            }
            return lista;
        }
        public Usuario_62_BP BuscarUsuarioPorNombre_62_BP(string nombre)
        {
            string query = "SELECT dni_62_BP, apellido_62_BP, nombre_62_BP, rol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP FROM Usuario_62_BP WHERE login_62_BP = @nombre";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", nombre)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                Usuario_62_BP usuario = new Usuario_62_BP();

                usuario.Dni_62_BP = fila["dni_62_BP"].ToString();
                usuario.Apellido_62_BP = fila["apellido_62_BP"].ToString();
                usuario.Nombre_62_BP = fila["nombre_62_BP"].ToString();
                usuario.Rol_62_BP = fila["rol_62_BP"].ToString();
                usuario.Email_62_BP = fila["email_62_BP"].ToString();
                usuario.Login_62_BP = fila["login_62_BP"].ToString();
                usuario.Contrasena_62_BP = fila["contrasena_62_BP"].ToString();
                usuario.Bloqueo_62_BP = Convert.ToBoolean(fila["bloqueo_62_BP"]);
                usuario.Activo_62_BP = Convert.ToBoolean(fila["activo_62_BP"]);

                return usuario;
            }
            return null;
        }

        public Usuario_62_BP BuscarUsuarioPorDNI_62_BP(string dni)
        {
            string query = "SELECT dni_62_BP, apellido_62_BP, nombre_62_BP, rol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP FROM Usuario_62_BP WHERE dni_62_BP = @dni";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", dni)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                Usuario_62_BP usuario = new Usuario_62_BP();

                usuario.Dni_62_BP = fila["dni_62_BP"].ToString();
                usuario.Apellido_62_BP = fila["apellido_62_BP"].ToString();
                usuario.Nombre_62_BP = fila["nombre_62_BP"].ToString();
                usuario.Rol_62_BP = fila["rol_62_BP"].ToString();
                usuario.Email_62_BP = fila["email_62_BP"].ToString();
                usuario.Login_62_BP = fila["login_62_BP"].ToString();
                usuario.Contrasena_62_BP = fila["contrasena_62_BP"].ToString();
                usuario.Bloqueo_62_BP = Convert.ToBoolean(fila["bloqueo_62_BP"]);
                usuario.Activo_62_BP = Convert.ToBoolean(fila["activo_62_BP"]);

                return usuario;
            }
            return null;
        }

        public int Alta_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Usuario_62_BP (dni_62_BP, apellido_62_BP, nombre_62_BP, rol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP) VALUES (@dni, @apellido, @nombre, @rol, @email, @login, @contrasena, 0, 1)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@apellido", usuario.Apellido_62_BP),
                new SqlParameter("@nombre", usuario.Nombre_62_BP),
                new SqlParameter("@rol", usuario.Rol_62_BP),
                new SqlParameter("@email", usuario.Email_62_BP),
                new SqlParameter("@login", usuario.Login_62_BP),
                new SqlParameter("@contrasena", usuario.Contrasena_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
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
            string query = "UPDATE Usuario_62_BP SET apellido_62_BP = @apellido, nombre_62_BP = @nombre, rol_62_BP = @rol, email_62_BP = @email, login_62_BP = @login WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@apellido", usuario.Apellido_62_BP),
                new SqlParameter("@nombre", usuario.Nombre_62_BP),
                new SqlParameter("@rol", usuario.Rol_62_BP),
                new SqlParameter("@email", usuario.Email_62_BP),
                new SqlParameter("@login", usuario.Login_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Bloquear_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET bloqueo_62_BP = 1 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Desbloquear_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET bloqueo_62_BP = 0 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int CambiarContrasena_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET contrasena_62_BP = @contrasena WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni_62_BP),
                new SqlParameter("@contrasena", usuario.Contrasena_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
    }
}
