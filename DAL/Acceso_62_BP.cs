using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
namespace DAL_62_BP
{
    public class Acceso_62_BP
    {
        SqlConnection conexion_62_BP = new SqlConnection(@"Data Source=.;Initial Catalog=TP_Campo_62_BP;Integrated Security=True;");

        public void abrir_62_BP()
        {
            conexion_62_BP.Open();
        }

        public void cerrar_62_BP()
        {
            conexion_62_BP.Close();
        }

        public DataTable leer_62_BP(string query, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            abrir_62_BP();
            SqlTransaction transaccion = conexion_62_BP.BeginTransaction();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexion_62_BP);
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
                cerrar_62_BP();
            }

            return tabla;
        }
        public int escribir_62_BP(string query, SqlParameter[] parametros)
        {
            int filasAfectadas = 0;
            abrir_62_BP();
            SqlTransaction transaccion = conexion_62_BP.BeginTransaction();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexion_62_BP);
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
                cerrar_62_BP();
            }

            return filasAfectadas;
        }
    }
}
