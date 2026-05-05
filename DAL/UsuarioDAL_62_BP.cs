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

        public DataTable BuscarUsuarioPorNombre(string nombre) {
            string query = "SELECT id, nombre, contrasenaHasheada, intentosLogin, rol FROM Usuario WHERE nombre = @nombre";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", nombre)
            };
            DataTable tabla = _acceso.leer(query, parametros);
            
            return tabla;
        }
    }
}
