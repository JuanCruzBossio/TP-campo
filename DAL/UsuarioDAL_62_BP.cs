using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using SEG;
namespace DAL
{
    public class UsuarioDAL_62_BP
    {
        private Acceso_62_BP _acceso = new Acceso_62_BP();
        public List<Usuario_62_BP> TraerTodosUsuarios()
        {
            List<Usuario_62_BP> lista = new List<Usuario_62_BP>();
            string query = "SELECT dni, apellido, nombre, rol, email, login, contrasena, bloqueo, activo FROM Usuario";

            DataTable tabla = _acceso.leer(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Usuario_62_BP usuario = new Usuario_62_BP();

                    usuario.Dni = fila["dni"].ToString();
                    usuario.Apellido = fila["apellido"].ToString();
                    usuario.Nombre = fila["nombre"].ToString();
                    usuario.Rol = fila["rol"].ToString();
                    usuario.Email = fila["email"].ToString();
                    usuario.Login = fila["login"].ToString();
                    usuario.Contrasena = fila["contrasena"].ToString();
                    usuario.Bloqueo = Convert.ToBoolean(fila["bloqueo"]);
                    usuario.Activo = Convert.ToBoolean(fila["activo"]);

                    lista.Add(usuario);
                }
            }
            return lista;
        }
        public Usuario_62_BP BuscarUsuarioPorNombre(string nombre)
        {
            string query = "SELECT dni, apellido, nombre, rol, email, login, contrasena, bloqueo, activo FROM Usuario WHERE login = @nombre";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", nombre)
            };

            DataTable tabla = _acceso.leer(query, parametros);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                Usuario_62_BP usuario = new Usuario_62_BP();

                usuario.Dni = fila["dni"].ToString();
                usuario.Apellido = fila["apellido"].ToString();
                usuario.Nombre = fila["nombre"].ToString();
                usuario.Rol = fila["rol"].ToString();
                usuario.Email = fila["email"].ToString();
                usuario.Login = fila["login"].ToString();
                usuario.Contrasena = fila["contrasena"].ToString();
                usuario.Bloqueo = Convert.ToBoolean(fila["bloqueo"]);
                usuario.Activo = Convert.ToBoolean(fila["activo"]);

                return usuario;
            }
            return null;
        }

        public int Alta(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Usuario (dni, apellido, nombre, rol, email, login, contrasena, bloqueo, activo) VALUES (@dni, @apellido, @nombre, @rol, @email, @login, @contrasena, 0, 1)";

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

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
        public int Activar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET activo = 1 WHERE dni = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
        public int Desactivar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET activo = 0 WHERE dni = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Modificar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET apellido = @apellido, nombre = @nombre, rol = @rol, email = @email, login = @login WHERE dni = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni),
                new SqlParameter("@apellido", usuario.Apellido),
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@rol", usuario.Rol),
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@login", usuario.Login)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Bloquear(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET bloqueo = 1 WHERE dni = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Desbloquear(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET bloqueo = 0 WHERE dni = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int CambiarContrasena(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET contrasena = @contrasena WHERE dni = @dni";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dni", usuario.Dni),
                new SqlParameter("@contrasena", usuario.Contrasena)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
    }
}
