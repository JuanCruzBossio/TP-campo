using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class SolicitudInsatisfechaBLL_62_BP
    {
        private SolicitudInsatisfechaMapper_62_BP _solicitudInsatisfechaMapper_62_BP = new SolicitudInsatisfechaMapper_62_BP();

        public int AgregarSolicitudInsatisfecha_62_BP(SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _solicitudInsatisfechaMapper_62_BP.AgregarSolicitudInsatisfecha_62_BP(solicitudInsatisfecha);
            }
            catch
            {
                throw new Exception("No se pudo agregar la solicitud insatisfecha.");
            }

            return filasAfectadas;
        }

        public int ModificarSolicitudInsatisfecha_62_BP(SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _solicitudInsatisfechaMapper_62_BP.ModificarSolicitudInsatisfecha_62_BP(solicitudInsatisfecha);
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
            bool? aceptada = null)
        {
            SolicitudInsatisfechaBE_62_BP solicitudInsatisfecha = null;

            try
            {
                solicitudInsatisfecha = _solicitudInsatisfechaMapper_62_BP.BuscarSolicitudInsatisfecha_62_BP(
                    id,
                    idLibro,
                    dniLector,
                    aceptada);
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
            bool? aceptada = null)
        {
            try
            {
                return _solicitudInsatisfechaMapper_62_BP.BuscarSolicitudesInsatisfechas_62_BP(
                    idSolicitud,
                    idLibro,
                    dniLector,
                    aceptada);
            }
            catch
            {
                throw new Exception("No se pudieron buscar las solicitudes insatisfechas.");
            }
        }
    }
}
