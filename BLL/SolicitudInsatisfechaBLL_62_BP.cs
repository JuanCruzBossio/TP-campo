using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;
using BLL;
using SEG_62_BP;

namespace BLL_62_BP
{
    public class SolicitudInsatisfechaBLL_62_BP
    {
        private SolicitudInsatisfechaMapper_62_BP _solicitudInsatisfechaMapper_62_BP = new SolicitudInsatisfechaMapper_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG_62_BP = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorBLL_62_BP = new DigitoVerificadorBLL_62_BP();

        public int AgregarSolicitudInsatisfecha_62_BP(SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _solicitudInsatisfechaMapper_62_BP.AgregarSolicitudInsatisfecha_62_BP(solicitudInsatisfecha);
                if (filasAfectadas > 0)
                {
                    ActualizarSolicitudInsatisfechaDVH_62_BP(filasAfectadas);
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "SolicitudInsatisfecha",
                        "AgregarSolicitudInsatisfecha",
                        "Alta de Solicitud de Libro N: " + filasAfectadas,
                        1);
                }
            }
            catch
            {
                throw new Exception("No se pudo agregar la solicitud insatisfecha.");
            }

            return filasAfectadas;
        }

        public int AceptarSolicitudInsatisfecha_62_BP(int idSolicitud)
        {
            try
            {
                int filasAfectadas = _solicitudInsatisfechaMapper_62_BP
                    .AceptarSolicitudInsatisfecha_62_BP(idSolicitud);

                if (filasAfectadas > 0)
                {
                    ActualizarSolicitudInsatisfechaDVH_62_BP(idSolicitud);
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "SolicitudInsatisfecha",
                        "AceptarSolicitudInsatisfecha",
                        "Aceptacion de Solicitud N: " + idSolicitud,
                        2);
                }

                return filasAfectadas;
            }
            catch
            {
                throw new Exception("No se pudo aceptar la solicitud insatisfecha.");
            }
        }

        public int CompletarSolicitudInsatisfecha_62_BP(int idSolicitud, DateTime fechaCompletada)
        {
            try
            {
                int filasAfectadas = _solicitudInsatisfechaMapper_62_BP
                    .CompletarSolicitudInsatisfecha_62_BP(idSolicitud, fechaCompletada);

                if (filasAfectadas > 0)
                {
                    ActualizarSolicitudInsatisfechaDVH_62_BP(idSolicitud);
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "SolicitudInsatisfecha",
                        "CompletarSolicitudInsatisfecha",
                        "Solicitud Completada N: " + idSolicitud,
                        2);
                }

                return filasAfectadas;
            }
            catch
            {
                throw new Exception("No se pudo completar la solicitud insatisfecha.");
            }
        }

        public int ModificarSolicitudInsatisfecha_62_BP(SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _solicitudInsatisfechaMapper_62_BP.ModificarSolicitudInsatisfecha_62_BP(solicitudInsatisfecha);
                if (filasAfectadas > 0)
                {
                    ActualizarSolicitudInsatisfechaDVH_62_BP(solicitudInsatisfecha.id_solicitud_62_BP);
                }
            }
            catch
            {
                throw new Exception("No se pudo modificar la solicitud insatisfecha.");
            }

            return filasAfectadas;
        }

        public SolicitudInsatisfechaBE_62_BP BuscarSolicitudInsatisfecha_62_BP(
            int? id = null,
            int idLibro = 0,
            string dniLector = null,
            bool? aceptada = null,
            bool? completada = null)
        {
            SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha = null;

            try
            {
                solicitudInsatisfecha = _solicitudInsatisfechaMapper_62_BP.BuscarSolicitudInsatisfecha_62_BP(
                    id,
                    idLibro,
                    dniLector,
                    aceptada,
                    completada);
            }
            catch
            {
                throw new Exception("No se pudo buscar la solicitud insatisfecha.");
            }

            return solicitudInsatisfecha;
        }

        public List<SolicitudInsatisfechaBE_62_BP> BuscarSolicitudesInsatisfechas_62_BP(
            int? idSolicitud = null,
            int? idLibro = null,
            string dniLector = null,
            bool? aceptada = null,
            bool? completada = null)
        {
            try
            {
                return _solicitudInsatisfechaMapper_62_BP.BuscarSolicitudesInsatisfechas_62_BP(
                    idSolicitud,
                    idLibro,
                    dniLector,
                    aceptada,
                    completada);
            }
            catch
            {
                throw new Exception("No se pudieron buscar las solicitudes insatisfechas.");
            }
        }

        public int ActualizarSolicitudInsatisfechaDVH_62_BP(int idSolicitud)
        {
            SolicitudInsatisfechaBE_62_BP solicitud = _solicitudInsatisfechaMapper_62_BP
                .BuscarSolicitudInsatisfecha_62_BP(id: idSolicitud);
            if (solicitud == null) return 0;
            string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(solicitud.ObtenerCadenaDVH_62_BP());
            int filas = _solicitudInsatisfechaMapper_62_BP.ActualizarDVH_62_BP(idSolicitud, dvh);
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("SolicitudInsatisfecha_62_BP");
            return filas;
        }

        public int RecalcularDVH_62_BP()
        {
            int filas = 0;
            foreach (SolicitudInsatisfechaBE_62_BP solicitud in
                _solicitudInsatisfechaMapper_62_BP.BuscarSolicitudesInsatisfechas_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(solicitud.ObtenerCadenaDVH_62_BP());
                filas += _solicitudInsatisfechaMapper_62_BP.ActualizarDVH_62_BP(solicitud.id_solicitud_62_BP, dvh);
            }
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("SolicitudInsatisfecha_62_BP");
            return filas;
        }

        public List<SolicitudInsatisfechaBE_62_BP> BuscarErrorDVH_62_BP()
        {
            List<SolicitudInsatisfechaBE_62_BP> errores = new List<SolicitudInsatisfechaBE_62_BP>();
            foreach (SolicitudInsatisfechaBE_62_BP solicitud in
                _solicitudInsatisfechaMapper_62_BP.BuscarSolicitudesInsatisfechas_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(solicitud.ObtenerCadenaDVH_62_BP());
                if (dvh != _solicitudInsatisfechaMapper_62_BP.BuscarDVH_62_BP(solicitud.id_solicitud_62_BP)) errores.Add(solicitud);
            }
            return errores;
        }
    }
}
