using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using SEG_62_BP;

namespace BLL_62_BP
{
    public class BitacoraBLL_62_BP
    {
        private BitacoraDAL_62_BP _bitacoraDAL = new BitacoraDAL_62_BP();

        public void AltaBitacora_62_BP(string mensaje, int nivelCriticidad)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Mensaje_62_BP = mensaje;
            registro.Criticidad_62_BP = nivelCriticidad;

            if (SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP != null)
            {
                registro.DniUsuario_62_BP = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Dni_62_BP;
            }
            else
            {
                registro.DniUsuario_62_BP = "0";
            }

            _bitacoraDAL.AltaBitacora_62_BP(registro);
        }
        public void AltaBitacora_62_BP(string mensaje, int nivelCriticidad, string dni)
        {
            RegistroBitacora_62_BP registro = new RegistroBitacora_62_BP();
            registro.Mensaje_62_BP = mensaje;
            registro.Criticidad_62_BP = nivelCriticidad;
            registro.DniUsuario_62_BP = dni;

            _bitacoraDAL.AltaBitacora_62_BP(registro);
        }
        public List<RegistroBitacora_62_BP> ObtenerBitacora_62_BP()
        {
            return _bitacoraDAL.ObtenerRegistros_62_BP();
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

            var resultados = _bitacoraDAL.FiltrarRegistros_62_BP(
                string.IsNullOrWhiteSpace(fechaIni) ? (DateTime?)null : fechaInicioParsed,
                string.IsNullOrWhiteSpace(fechaFin) ? (DateTime?)null : fechaFinParsed,
                login,
                modulo,
                evento,
                string.IsNullOrWhiteSpace(criticidad) ? (int?)null : criticidadParsed
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
            _bitacoraDAL.ExportarBitacoraAPDF(registros, rutaArchivo);
        }

    }
}
