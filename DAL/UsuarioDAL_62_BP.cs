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

        public Usuario_62_BP BuscarUsuarioPorNombre(string nombre)
        {
            string query = "SELECT id, nombre, contrasenaHasheada, intentosLogin, rol FROM Usuario WHERE nombre = @nombre AND baja = false";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", nombre)
            };

            DataTable tabla = _acceso.leer(query, parametros);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                Usuario_62_BP usuario = new Usuario_62_BP();

                usuario.Id = Convert.ToInt32(fila["id"]);
                usuario.Nombre = fila["nombre"].ToString();
                usuario.ContrasenaHasheada = fila["contrasenaHasheada"].ToString();
                usuario.IntentosLogin = Convert.ToInt32(fila["intentosLogin"]);
                usuario.Rol = Convert.ToInt32(fila["rol"]);

                return usuario;
            }
            return null;
        }

        public int Alta(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Usuario (nombre, contrasenaHasheada, intentosLogin, rol, baja) VALUES (@nombre, @contrasenaHasheada, 0, @rol, FALSE)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@contrasenaHasheada", usuario.ContrasenaHasheada),
                new SqlParameter("@rol", usuario.Rol)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
        public int BajaLogica(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET baja = TRUE WHERE id = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", usuario.Id)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Modificar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET nombre = @nombre, contrasenaHasheada = @contrasenaHasheada, rol = @rol WHERE id = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", usuario.Id),
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@contrasenaHasheada", usuario.ContrasenaHasheada),
                new SqlParameter("@rol", usuario.Rol)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Habilitar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET intentosLogin = 0, baja = FALSE WHERE id = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", usuario.Id)
            };

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
    }
}
