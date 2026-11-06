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
            string query = "INSERT INTO Libro_62_BP (titulo_62_BP, autor_62_BP, isbn_62_BP, genero_62_BP, numero_volumen_62_BP, prestado_62_BP) OUTPUT INSERTED.id_libro_62_BP VALUES (@titulo, @autor, @isbn, @genero, @numeroVolumen, @prestado);";

            SqlParameter[] parametros =
            {
                new SqlParameter("@titulo", libro.titulo_62_BP),
                new SqlParameter("@autor", libro.autor_62_BP),
                new SqlParameter("@isbn", libro.isbn_62_BP),
                new SqlParameter("@genero", libro.genero_62_BP),
                new SqlParameter("@numeroVolumen", libro.numero_volumen_62_BP),
                new SqlParameter("@prestado", libro.prestado_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt32(Convert.ToDecimal(resultado));
        }

        public int ModificarLibro_62_BP(LibroBE_62_BP libro)
        {
            string query = "UPDATE Libro_62_BP SET titulo_62_BP = @titulo, autor_62_BP = @autor, isbn_62_BP = @isbn, genero_62_BP = @genero, numero_volumen_62_BP = @numeroVolumen, prestado_62_BP = @prestado WHERE id_libro_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", libro.id_libro_62_BP),
                new SqlParameter("@titulo", libro.titulo_62_BP),
                new SqlParameter("@autor", libro.autor_62_BP),
                new SqlParameter("@isbn", libro.isbn_62_BP),
                new SqlParameter("@genero", libro.genero_62_BP),
                new SqlParameter("@numeroVolumen", libro.numero_volumen_62_BP),
                new SqlParameter("@prestado", libro.prestado_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public LibroBE_62_BP BuscarLibro_62_BP(int? id = null, string titulo = null, string isbn = null, bool? prestado = null)
        {
            StringBuilder query = new StringBuilder("SELECT id_libro_62_BP, titulo_62_BP, autor_62_BP, isbn_62_BP, genero_62_BP, numero_volumen_62_BP, prestado_62_BP FROM Libro_62_BP WHERE 1 = 1");

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

            if (prestado.HasValue)
            {
                query.Append(" AND prestado_62_BP = @prestado");
                parametros.Add(new SqlParameter("@prestado", prestado.Value));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new LibroBE_62_BP
                {
                    id_libro_62_BP = Convert.ToInt32(tabla.Rows[0]["id_libro_62_BP"]),
                    titulo_62_BP = tabla.Rows[0]["titulo_62_BP"].ToString(),
                    autor_62_BP = tabla.Rows[0]["autor_62_BP"].ToString(),
                    isbn_62_BP = tabla.Rows[0]["isbn_62_BP"].ToString(),
                    genero_62_BP = tabla.Rows[0]["genero_62_BP"] as string ?? string.Empty,
                    numero_volumen_62_BP = Convert.ToInt32(tabla.Rows[0]["numero_volumen_62_BP"]),
                    prestado_62_BP = Convert.ToBoolean(tabla.Rows[0]["prestado_62_BP"])
                };
            }

            return null;
        }

        public List<LibroBE_62_BP> BuscarTodosLosLibros_62_BP(bool? prestado = null)
        {
            StringBuilder query = new StringBuilder("SELECT id_libro_62_BP, titulo_62_BP, autor_62_BP, isbn_62_BP, genero_62_BP, numero_volumen_62_BP, prestado_62_BP FROM Libro_62_BP WHERE 1 = 1");
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (prestado.HasValue)
            {
                query.Append(" AND prestado_62_BP = @prestado");
                parametros.Add(new SqlParameter("@prestado", prestado.Value));
            }

            query.Append(" ORDER BY id_libro_62_BP ASC");

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            List<LibroBE_62_BP> lista = new List<LibroBE_62_BP>();

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    lista.Add(new LibroBE_62_BP
                    {
                        id_libro_62_BP = Convert.ToInt32(row["id_libro_62_BP"]),
                        titulo_62_BP = row["titulo_62_BP"].ToString(),
                        autor_62_BP = row["autor_62_BP"].ToString(),
                        isbn_62_BP = row["isbn_62_BP"].ToString(),
                        genero_62_BP = row["genero_62_BP"] as string ?? string.Empty,
                        numero_volumen_62_BP = Convert.ToInt32(row["numero_volumen_62_BP"]),
                        prestado_62_BP = Convert.ToBoolean(row["prestado_62_BP"])
                    });
                }
            }

            return lista;
        }

        public List<LibroBE_62_BP> BuscarLibrosConFiltros_62_BP(string titulo, string autor, string genero, string isbn, bool? prestado = null)
        {
            StringBuilder query = new StringBuilder("SELECT id_libro_62_BP, titulo_62_BP, autor_62_BP, isbn_62_BP, genero_62_BP, numero_volumen_62_BP, prestado_62_BP FROM Libro_62_BP WHERE 1 = 1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                query.Append(" AND titulo_62_BP LIKE @titulo");
                parametros.Add(new SqlParameter("@titulo", "%" + titulo + "%"));
            }

            if (!string.IsNullOrWhiteSpace(autor))
            {
                query.Append(" AND autor_62_BP LIKE @autor");
                parametros.Add(new SqlParameter("@autor", "%" + autor + "%"));
            }

            if (!string.IsNullOrWhiteSpace(genero))
            {
                query.Append(" AND genero_62_BP LIKE @genero");
                parametros.Add(new SqlParameter("@genero", "%" + genero + "%"));
            }

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                query.Append(" AND isbn_62_BP LIKE @isbn");
                parametros.Add(new SqlParameter("@isbn", "%" + isbn + "%"));
            }

            if (prestado.HasValue)
            {
                query.Append(" AND prestado_62_BP = @prestado");
                parametros.Add(new SqlParameter("@prestado", prestado.Value));
            }

            query.Append(" ORDER BY id_libro_62_BP ASC");

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            List<LibroBE_62_BP> lista = new List<LibroBE_62_BP>();

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    lista.Add(new LibroBE_62_BP
                    {
                        id_libro_62_BP = Convert.ToInt32(row["id_libro_62_BP"]),
                        titulo_62_BP = row["titulo_62_BP"].ToString(),
                        autor_62_BP = row["autor_62_BP"].ToString(),
                        isbn_62_BP = row["isbn_62_BP"].ToString(),
                        genero_62_BP = row["genero_62_BP"] as string ?? string.Empty,
                        numero_volumen_62_BP = Convert.ToInt32(row["numero_volumen_62_BP"]),
                        prestado_62_BP = Convert.ToBoolean(row["prestado_62_BP"])
                    });
                }
            }

            return lista;
        }

        public int MarcarPrestado_62_BP(int idLibro)
        {
            string query = "UPDATE Libro_62_BP SET prestado_62_BP = 1 WHERE id_libro_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", idLibro)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int MarcarDisponible_62_BP(int idLibro)
        {
            string query = "UPDATE Libro_62_BP SET prestado_62_BP = 0 WHERE id_libro_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", idLibro)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }
    }
}
