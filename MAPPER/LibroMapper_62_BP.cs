using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using BE_62_BP;

namespace MAPPER_62_BP
{
    public class LibroMapper_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AgregarLibro_62_BP(LibroBE_62_BP libro)
        {
            string query = "INSERT INTO Libro_62_BP (titulo_62_BP, autor_62_BP, isbn_62_BP) VALUES (@titulo, @autor, @isbn);SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros =
            {
                new SqlParameter("@titulo", libro.titulo_62_BP),
                new SqlParameter("@autor", libro.autor_62_BP),
                new SqlParameter("@isbn", libro.isbn_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            return Convert.ToInt32(Convert.ToDecimal(resultado));
        }

        public int ModificarLibro_62_BP(LibroBE_62_BP libro)
        {
            string query = "UPDATE Libro_62_BP SET titulo_62_BP = @titulo, autor_62_BP = @autor, isbn_62_BP = @isbn WHERE id_libro_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", libro.id_libro_62_BP),
                new SqlParameter("@titulo", libro.titulo_62_BP),
                new SqlParameter("@autor", libro.autor_62_BP),
                new SqlParameter("@isbn", libro.isbn_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public LibroBE_62_BP BuscarLibro_62_BP(int? id = null, string titulo = null, string isbn = null)
        {
            StringBuilder query = new StringBuilder("SELECT id_libro_62_BP, titulo_62_BP, autor_62_BP, isbn_62_BP FROM Libro_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND id_libro_62_BP = @id");
                parametros.Add(new SqlParameter("@id", id.Value));
            }

            if (!string.IsNullOrEmpty(titulo))
            {
                query.Append(" AND titulo_62_BP = @titulo");
                parametros.Add(new SqlParameter("@titulo", titulo));
            }

            if (!string.IsNullOrEmpty(isbn))
            {
                query.Append(" AND isbn_62_BP = @isbn");
                parametros.Add(new SqlParameter("@isbn", isbn));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new LibroBE_62_BP
                {
                    id_libro_62_BP = Convert.ToInt32(tabla.Rows[0]["id_libro_62_BP"]),
                    titulo_62_BP = tabla.Rows[0]["titulo_62_BP"].ToString(),
                    autor_62_BP = tabla.Rows[0]["autor_62_BP"].ToString(),
                    isbn_62_BP = tabla.Rows[0]["isbn_62_BP"].ToString()
                };
            }

            return null;
        }
    }
}
