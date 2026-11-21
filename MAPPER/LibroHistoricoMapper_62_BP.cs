using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BE_62_BP;
using DAL_62_BP;

namespace MAPPER_62_BP
{
    public class LibroHistoricoMapper_62_BP
    {
        private readonly Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public List<LibroHistoricoBE_62_BP> BuscarTodosLosHistoricos_62_BP()
        {
            return BuscarHistoricos_62_BP();
        }

        public LibroHistoricoBE_62_BP BuscarHistoricoPorId_62_BP(int idHistorico)
        {
            const string query = @"
                SELECT
                    id_historico_62_BP,
                    id_libro_62_BP,
                    titulo_62_BP,
                    autor_62_BP,
                    isbn_62_BP,
                    genero_62_BP,
                    numero_volumen_62_BP,
                    prestado_62_BP,
                    DVH_62_BP,
                    actual_62_BP,
                    fecha_actualizacion_62_BP
                FROM dbo.LibroHistorico_62_BP
                WHERE id_historico_62_BP = @idHistorico;";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idHistorico", idHistorico)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);
            if (tabla == null || tabla.Rows.Count == 0)
            {
                return null;
            }

            return MapearHistorico_62_BP(tabla.Rows[0]);
        }

        public int RecuperarEstado_62_BP(int idHistorico)
        {
            const string query = @"
                EXEC dbo.RecuperarLibroHistorico_62_BP
                    @idHistorico_62_BP = @idHistorico;";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idHistorico", idHistorico)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }

        public List<LibroHistoricoBE_62_BP> BuscarHistoricos_62_BP(
            int? idLibro = null,
            bool? prestado = null,
            bool? actual = null)
        {
            StringBuilder query = new StringBuilder(@"
                SELECT
                    id_historico_62_BP,
                    id_libro_62_BP,
                    titulo_62_BP,
                    autor_62_BP,
                    isbn_62_BP,
                    genero_62_BP,
                    numero_volumen_62_BP,
                    prestado_62_BP,
                    DVH_62_BP,
                    actual_62_BP,
                    fecha_actualizacion_62_BP
                FROM dbo.LibroHistorico_62_BP
                WHERE 1 = 1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (idLibro.HasValue)
            {
                query.Append(" AND id_libro_62_BP = @idLibro");
                parametros.Add(new SqlParameter("@idLibro", idLibro.Value));
            }

            if (prestado.HasValue)
            {
                query.Append(" AND prestado_62_BP = @prestado");
                parametros.Add(new SqlParameter("@prestado", prestado.Value));
            }

            if (actual.HasValue)
            {
                query.Append(" AND actual_62_BP = @actual");
                parametros.Add(new SqlParameter("@actual", actual.Value));
            }

            query.Append(@"
                ORDER BY
                    fecha_actualizacion_62_BP DESC,
                    id_historico_62_BP DESC;");

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());
            List<LibroHistoricoBE_62_BP> historicos = new List<LibroHistoricoBE_62_BP>();

            if (tabla == null)
            {
                return historicos;
            }

            foreach (DataRow fila in tabla.Rows)
            {
                historicos.Add(MapearHistorico_62_BP(fila));
            }

            return historicos;
        }

        private LibroHistoricoBE_62_BP MapearHistorico_62_BP(DataRow fila)
        {
            return new LibroHistoricoBE_62_BP
            {
                id_historico_62_BP = Convert.ToInt32(fila["id_historico_62_BP"]),
                id_libro_62_BP = Convert.ToInt32(fila["id_libro_62_BP"]),
                titulo_62_BP = Convert.ToString(fila["titulo_62_BP"]),
                autor_62_BP = Convert.ToString(fila["autor_62_BP"]),
                isbn_62_BP = Convert.ToString(fila["isbn_62_BP"]),
                genero_62_BP = Convert.ToString(fila["genero_62_BP"]),
                numero_volumen_62_BP = Convert.ToInt32(fila["numero_volumen_62_BP"]),
                prestado_62_BP = Convert.ToBoolean(fila["prestado_62_BP"]),
                DVH_62_BP = fila["DVH_62_BP"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToString(fila["DVH_62_BP"]),
                actual_62_BP = Convert.ToBoolean(fila["actual_62_BP"]),
                fecha_actualizacion_62_BP = Convert.ToDateTime(fila["fecha_actualizacion_62_BP"])
            };
        }
    }
}
