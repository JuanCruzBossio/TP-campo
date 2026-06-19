using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL_62_BP;
using SEG_62_BP;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DAL;
using SEG.Permisos_62_BP;
using BLL;
namespace BLL_62_BP
{
    public class BitacoraBLL_62_BP
    {
        private BitacoraDAL_62_BP _bitacoraDAL = new BitacoraDAL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorDAL = new DigitoVerificadorBLL_62_BP();

        public void RegistrarBitacora_62_BP(string mensaje, int nivelCriticidad)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Criticidad_62_BP = nivelCriticidad;
            registro.Mensaje_62_BP = mensaje;
            if (SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP != null)
            {
                registro.DniUsuario_62_BP = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Dni_62_BP;
            }
            else
            {
                registro.DniUsuario_62_BP = "0";
            }
            int id = _bitacoraDAL.RegistrarBitacora_62_BP(registro);
            ActualizarBitacoraDVH_62_BP(id);
        }
        public void RegistrarBitacora_62_BP(string mensaje, int nivelCriticidad, string dni)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Criticidad_62_BP = nivelCriticidad;
            registro.DniUsuario_62_BP = dni;
            registro.Mensaje_62_BP = mensaje;

            int id = _bitacoraDAL.RegistrarBitacora_62_BP(registro);
            ActualizarBitacoraDVH_62_BP(id);
        }
        public List<RegistroBitacora_62_BP> ObtenerBitacora_62_BP()
        {
            List<RegistroBitacora_62_BP> lista = _bitacoraDAL.ObtenerRegistros_62_BP();
            return lista;
        }
        public List<RegistroBitacora_62_BP> FiltrarBitacora_62_BP(
        string fechaIni, string fechaFin, string login, string modulo, string evento, string criticidad, out string error)
        {
            error = string.Empty;
            DateTime fechaInicioParsed = DateTime.MinValue, fechaFinParsed = DateTime.MinValue;
            int criticidadParsed = 0;

            if (!string.IsNullOrWhiteSpace(fechaIni) && !DateTime.TryParse(fechaIni, out fechaInicioParsed))
            {
                error = "La fecha de inicio es inválida.";
                return null;
            }
            if (!string.IsNullOrWhiteSpace(fechaFin) && !DateTime.TryParse(fechaFin, out fechaFinParsed))
            {
                error = "La fecha de fin es inválida.";
                return null;
            }
            if (!string.IsNullOrWhiteSpace(fechaIni) && !string.IsNullOrWhiteSpace(fechaFin) && fechaInicioParsed > fechaFinParsed)
            {
                error = "La fecha de inicio no puede ser mayor que la fecha de fin.";
                return null;
            }
            if (!string.IsNullOrWhiteSpace(criticidad))
            {
                if (!int.TryParse(criticidad, out criticidadParsed) || criticidadParsed < 1 || criticidadParsed > 5)
                {
                    error = "La criticidad debe ser un número entre 1 y 5.";
                    return null;
                }
            }

            var resultados = _bitacoraDAL.ObtenerRegistros_62_BP(
                fechaIni: string.IsNullOrWhiteSpace(fechaIni) ? (DateTime?)null : fechaInicioParsed,
                fechaFin: string.IsNullOrWhiteSpace(fechaFin) ? (DateTime?)null : fechaFinParsed,
                login: string.IsNullOrWhiteSpace(login) ? null: login,
                modulo: string.IsNullOrWhiteSpace(modulo) ? null: modulo,
                evento: string.IsNullOrWhiteSpace(evento) ? null: evento,
                criticidad: string.IsNullOrWhiteSpace(criticidad) ? (int?)null : criticidadParsed
            );

            if (resultados == null || resultados.Count == 0)
            {
                error = "No se encontraron registros con los filtros aplicados.";
                return null;
            }
            return resultados;
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
        public int ActualizarBitacoraDVH_62_BP(int id)
        {
            int filasAfectadas = 0;
            RegistroBitacora_62_BP bitacora = null;
            try
            {
                bitacora = _bitacoraDAL.ObtenerRegistro_62_BP( id);
                if (bitacora != null)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(bitacora.ObtenerCadenaDVH_62_BP());
                    filasAfectadas = _bitacoraDAL.ActualizarDVH_62_BP(id, dvh);
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Bitacora_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int RecalcularBitacorasDVH_62_BP()
        {
            int filasAfectadas = 0;
            try
            {
                List<RegistroBitacora_62_BP> registros = _bitacoraDAL.ObtenerRegistros_62_BP();
                if (registros != null)
                {
                    foreach (var registro in registros)
                    {
                        string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(registro.ObtenerCadenaDVH_62_BP());
                        _bitacoraDAL.ActualizarDVH_62_BP(registro.Id_62_BP, dvh);
                        filasAfectadas++;
                    }
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Bitacora_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public List<RegistroBitacora_62_BP> BuscarErrorDVH_62_BP()
        {
            List<RegistroBitacora_62_BP> errores = new List<RegistroBitacora_62_BP>();
            try
            {
                List<RegistroBitacora_62_BP> lista = ObtenerBitacora_62_BP();
                foreach (var registro in lista)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(registro.ObtenerCadenaDVH_62_BP());
                    if (dvh != _bitacoraDAL.BuscarDVH_62_BP(registro.Id_62_BP))
                    {
                        errores.Add(registro);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al revisar Datos DVH Bitacora.");
            }
            return errores;
        }
    }
}
