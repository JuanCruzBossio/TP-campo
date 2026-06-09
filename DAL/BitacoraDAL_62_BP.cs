using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG_62_BP;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Xml.Linq;
using System.Net;

namespace DAL_62_BP
{
    public class BitacoraDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();
        private RegistroBitacora_62_BP MapearRegistro(DataRow fila)
        {
            return new RegistroBitacora_62_BP
            {
                Id_62_BP = Convert.ToInt32(fila["id_62_BP"]),
                Fecha_62_BP = Convert.ToDateTime(fila["fecha_62_BP"]),
                DniUsuario_62_BP = fila["dniUsuario_62_BP"].ToString(),
                Mensaje_62_BP = fila["mensaje_62_BP"].ToString(),
                Criticidad_62_BP = Convert.ToInt32(fila["criticidad_62_BP"])
            };
        }
        public int RegistrarBitacora_62_BP(RegistroBitacora_62_BP registro)
        {
            var id = 0;
            string query = "INSERT INTO Bitacora_62_BP (fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP) VALUES (GETDATE(), @dniUsuario, @mensaje, @criticidad);SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dniUsuario", registro.DniUsuario_62_BP),
                new SqlParameter("@mensaje", registro.Mensaje_62_BP),
                new SqlParameter("@criticidad", registro.Criticidad_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            id = Convert.ToInt32(Convert.ToDecimal(resultado));
            return id;
        }
      
        public List<RegistroBitacora_62_BP> ObtenerRegistros_62_BP(
            DateTime? fechaIni = null, DateTime? fechaFin = null, string login = null, string modulo = null, string evento = null, int? criticidad = null, int ? id_62_BP = null)
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            StringBuilder query = new StringBuilder("SELECT id_62_BP, fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP FROM Bitacora_62_BP WHERE 1=1");

            if (fechaIni.HasValue)
            {
                query.Append(" AND Fecha_62_BP >= @fechaIni");
                parametros.Add(new SqlParameter("@fechaIni", fechaIni.Value));
            }
            if (fechaFin.HasValue)
            {
                query.Append(" AND Fecha_62_BP <= @fechaFin");
                parametros.Add(new SqlParameter("@fechaFin", fechaFin.Value));
            }
            if (!string.IsNullOrWhiteSpace(login))
            {
                query.Append(" AND DniUsuario_62_BP = @login");
                parametros.Add(new SqlParameter("@login", login));
            }
            // El filtro de modulo NO se usa
            if (!string.IsNullOrWhiteSpace(evento))
            {
                query.Append(" AND Mensaje_62_BP LIKE @evento");
                parametros.Add(new SqlParameter("@evento", "%" + evento + "%"));
            }
            if (criticidad.HasValue)
            {
                query.Append(" AND Criticidad_62_BP = @criticidad");
                parametros.Add(new SqlParameter("@criticidad", criticidad.Value));
            }
            if (id_62_BP.HasValue)
            {
                query.Append(" AND Criticidad_62_BP = @criticidad");
                parametros.Add(new SqlParameter("@id_62_BP", id_62_BP.ToString()));
            }

            query.Append(" ORDER BY fecha_62_BP DESC");

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(MapearRegistro(fila));
                }
            }
            return lista;
        }
        public RegistroBitacora_62_BP ObtenerRegistro_62_BP(int ? id_62_BP = null)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            List<SqlParameter> parametros = new List<SqlParameter>();
            StringBuilder query = new StringBuilder("SELECT * FROM Bitacora_62_BP WHERE 1=1");

            if (id_62_BP.HasValue)
            {
                query.Append(" AND id_62_BP = @id_62_BP");
                parametros.Add(new SqlParameter("@id_62_BP", id_62_BP.ToString()));
            }

            query.Append(" ORDER BY fecha_62_BP DESC");

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null)
            {
                registro =  MapearRegistro(tabla.Rows[0]);
            }
            return registro;
        }
        public int ActualizarDVH_62_BP(int id, string DVH_62_BP)
        {
            var filasAfectadas = 0;
            string query = "UPDATE Bitacora_62_BP SET DVH_62_BP = @dvh WHERE id_62_BP = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@dvh", DVH_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }
        public string BuscarDVH_62_BP(int id)
        {
            var dvh = "";
            string query = "SELECT *  FROM Bitacora_62_BP WHERE id_62_BP = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, parametros);

            if (tabla != null && tabla.Rows.Count > 0)
            {
                dvh = tabla.Rows[0]["DVH_62_BP"].ToString();
            }
            return dvh;
        }
    }
}
