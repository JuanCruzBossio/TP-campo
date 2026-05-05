using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public class UsuarioDAL_62_BP
    {
        private Acceso_62_BP _acceso = new Acceso_62_BP();

        public DataTable BuscarUsuarioPorNombre(string nombre)
        {
            string query = "SELECT id, nombre, contrasenaHasheada, intentosLogin, rol FROM Usuario WHERE nombre = @nombre AND baja = false";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", nombre)
            };
            DataTable tabla = _acceso.leer(query, parametros);

            return tabla;
        }

        public int Alta(SqlParameter[] parametros)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Usuario (nombre, contrasenaHasheada, intentosLogin, rol, baja) VALUES (@nombre, @contrasenaHasheada, 0, @rol, FALSE)";

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
        public int BajaLogica(SqlParameter[] parametros)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET baja = TRUE WHERE id = @id";

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Modificar(SqlParameter[] parametros)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET nombre = @nombre, contrasenaHasheada = @contrasenaHasheada, rol = @rol WHERE id = @id";

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }

        public int Habilitar(SqlParameter[] parametros)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Usuario SET baja = false WHERE id = @id";

            filasAfectadas = _acceso.escribir(query, parametros);
            return filasAfectadas;
        }
    }
}
