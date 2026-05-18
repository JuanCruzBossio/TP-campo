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

namespace DAL_62_BP
{
    public class BitacoraDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AltaBitacora_62_BP(RegistroBitacora_62_BP registro)
        {
            var filasAfectadas = 0;
            string query = "INSERT INTO Bitacora_62_BP (fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP) VALUES (GETDATE(), @dniUsuario, @mensaje, @criticidad)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@dniUsuario", registro.DniUsuario_62_BP),
                new SqlParameter("@mensaje", registro.Mensaje_62_BP),
                new SqlParameter("@criticidad", registro.Criticidad_62_BP)
            };

            filasAfectadas = _acceso_62_BP.escribir_62_BP(query, parametros);
            return filasAfectadas;
        }

        public List<RegistroBitacora_62_BP> ObtenerRegistros_62_BP()
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            string query = "SELECT id_62_BP, fecha_62_BP, dniUsuario_62_BP, mensaje_62_BP, criticidad_62_BP FROM Bitacora_62_BP ORDER BY fecha_62_BP DESC";
            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();

                    registro.Id_62_BP = Convert.ToInt32(fila["id_62_BP"]);
                    registro.Fecha_62_BP = Convert.ToDateTime(fila["fecha_62_BP"]);
                    registro.DniUsuario_62_BP = fila["dniUsuario_62_BP"].ToString();
                    registro.Mensaje_62_BP = fila["mensaje_62_BP"].ToString();
                    registro.Criticidad_62_BP = Convert.ToInt32(fila["criticidad_62_BP"]);

                    lista.Add(registro);
                }
            }
            return lista;
        }

        public List<RegistroBitacora_62_BP> FiltrarRegistros_62_BP(
        DateTime? fechaIni, DateTime? fechaFin, string login, string modulo, string evento, int? criticidad)
        {
            List<RegistroBitacora_62_BP> lista = new List<RegistroBitacora_62_BP>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            StringBuilder query = new StringBuilder("SELECT * FROM Bitacora_62_BP WHERE 1=1");

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

            DataTable dt = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new RegistroBitacora_62_BP
                {
                    Id_62_BP = Convert.ToInt32(row["Id_62_BP"]),
                    Fecha_62_BP = Convert.ToDateTime(row["Fecha_62_BP"]),
                    DniUsuario_62_BP = row["DniUsuario_62_BP"].ToString(),
                    Mensaje_62_BP = row["Mensaje_62_BP"].ToString(),
                    Criticidad_62_BP = Convert.ToInt32(row["Criticidad_62_BP"])
                });
            }
            return lista;
        }

        public void ExportarBitacoraAPDF(List<RegistroBitacora_62_BP> registros, string rutaArchivo)
        {
            Document doc = new Document(PageSize.A4);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                doc.Add(new Paragraph("Bitácora - Exportación"));
                doc.Add(new Paragraph(" "));

                PdfPTable tabla = new PdfPTable(5);
                tabla.WidthPercentage = 100;
                tabla.AddCell("ID");
                tabla.AddCell("Fecha");
                tabla.AddCell("DNI Usuario");
                tabla.AddCell("Mensaje");
                tabla.AddCell("Criticidad");

                foreach (var reg in registros)
                {
                    tabla.AddCell(reg.Id_62_BP.ToString());
                    tabla.AddCell(reg.Fecha_62_BP.ToString("yyyy-MM-dd HH:mm:ss"));
                    tabla.AddCell(reg.DniUsuario_62_BP);
                    tabla.AddCell(reg.Mensaje_62_BP);
                    tabla.AddCell(reg.Criticidad_62_BP.ToString());
                }

                doc.Add(tabla);
            }
            finally
            {
                doc.Close();
            }
        }

    }
}
