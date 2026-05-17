using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using SEG;
namespace DAL_62_BP
{
    public class UsuarioDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();
        public List<Usuario_62_BP> TraerTodosUsuarios()
        {
            List<Usuario_62_BP> lista = new List<Usuario_62_BP>();
            string query = "SELECT dni_62_BP, apellido_62_BP, nombre_62_BP, rol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP FROM Usuario_62_BP";

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Usuario_62_BP usuario = new Usuario_62_BP();

                    usuario.Dni = fila["dni_62_BP"].ToString();
                    usuario.Apellido = fila["apellido_62_BP"].ToString();
                    usuario.Nombre = fila["nombre_62_BP"].ToString();
                    usuario.Rol = fila["rol_62_BP"].ToString();
                    usuario.Email = fila["email_62_BP"].ToString();
                    usuario.Login = fila["login_62_BP"].ToString();
                    usuario.Contrasena = fila["contrasena_62_BP"].ToString();
                    usuario.Bloqueo = Convert.ToBoolean(fila["bloqueo_62_BP"]);
                    usuario.Activo = Convert.ToBoolean(fila["activo_62_BP"]);

                    lista.Add(usuario);
                }
            }
            return lista;
        }
        public Usuario_62_BP BuscarUsuarioPorNombre(string nombre)
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

                usuario.Dni = fila["dni_62_BP"].ToString();
                usuario.Apellido = fila["apellido_62_BP"].ToString();
                usuario.Nombre = fila["nombre_62_BP"].ToString();
                usuario.Rol = fila["rol_62_BP"].ToString();
                usuario.Email = fila["email_62_BP"].ToString();
                usuario.Login = fila["login_62_BP"].ToString();
                usuario.Contrasena = fila["contrasena_62_BP"].ToString();
                usuario.Bloqueo = Convert.ToBoolean(fila["bloqueo_62_BP"]);
                usuario.Activo = Convert.ToBoolean(fila["activo_62_BP"]);

                return usuario;
            }
            return null;
        }

        public Usuario_62_BP BuscarUsuarioPorDNI(string dni)
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

                usuario.Dni = fila["dni_62_BP"].ToString();
                usuario.Apellido = fila["apellido_62_BP"].ToString();
                usuario.Nombre = fila["nombre_62_BP"].ToString();
                usuario.Rol = fila["rol_62_BP"].ToString();
                usuario.Email = fila["email_62_BP"].ToString();
                usuario.Login = fila["login_62_BP"].ToString();
                usuario.Contrasena = fila["contrasena_62_BP"].ToString();
                usuario.Bloqueo = Convert.ToBoolean(fila["bloqueo_62_BP"]);
                usuario.Activo = Convert.ToBoolean(fila["activo_62_BP"]);

                return usuario;
            }
            return null;
        }

        public int Alta(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Usuario_62_BP (dni_62_BP, apellido_62_BP, nombre_62_BP, rol_62_BP, email_62_BP, login_62_BP, contrasena_62_BP, bloqueo_62_BP, activo_62_BP) VALUES (@dni, @apellido, @nombre, @rol, @email, @login, @contrasena, 0, 1)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni),
                new SqlParameter("@apellido", usuario.Apellido),
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@rol", usuario.Rol),
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@login", usuario.Login),
                new SqlParameter("@contrasena", usuario.Contrasena)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public int Activar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET activo_62_BP = 1 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public int Desactivar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET activo_62_BP = 0 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Modificar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET apellido_62_BP = @apellido, nombre_62_BP = @nombre, rol_62_BP = @rol, email_62_BP = @email, login_62_BP = @login WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni),
                new SqlParameter("@apellido", usuario.Apellido),
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@rol", usuario.Rol),
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@login", usuario.Login)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Bloquear(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET bloqueo_62_BP = 1 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int Desbloquear(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET bloqueo_62_BP = 0 WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public int CambiarContrasena(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario_62_BP SET contrasena_62_BP = @contrasena WHERE dni_62_BP = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni),
                new SqlParameter("@contrasena", usuario.Contrasena)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
    }
}
