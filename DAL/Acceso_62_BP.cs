using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
namespace DAL
{
    public class Acceso_62_BP
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=TP Campo;Integrated Security=True");

        public void abrir()
        {
            conexion.Open();
        }

        public void cerrar()
        {
            conexion.Close();
        }

        public DataTable leer(string query, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            abrir();
            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Transaction = transaccion;
                comando.CommandType = CommandType.Text;

                if (parametros != null && parametros.Length > 0)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        comando.Parameters.Add(param);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);

                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                throw;
            }
            finally
            {
                cerrar();
            }

            return tabla;
        }
        public int escribir(string query, SqlParameter[] parametros)
        {
            int filasAfectadas = 0;
            abrir();
            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Transaction = transaccion;
                comando.CommandType = CommandType.Text;

                if (parametros != null && parametros.Length > 0)
                {
                    comando.Parameters.AddRange(parametros);
                }

                filasAfectadas = comando.ExecuteNonQuery();

                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                throw;
            }
            finally
            {
                cerrar();
            }

            return filasAfectadas;
        }
    }
}
