using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using DIGITO_62_BP;

namespace BE_62_BP
{
    public class SolicitudInsatisfechaBE_62_BP : IDigitoVerificadorHorizontal_62_BP
    {
        public int id_solicitud_62_BP { get; set; }
        public int id_libro_62_BP { get; set; }
        public string dni_lector_62_BP { get; set; }
        public DateTime fecha_62_BP { get; set; }
        public bool aceptada_62_BP { get; set; } = false;
        public bool completada_62_BP { get; set; } = false;
        public DateTime? fecha_completada_62_BP { get; set; }

        public string ObtenerCadenaDVH_62_BP()
        {
            return id_solicitud_62_BP.ToString() +
                   id_libro_62_BP.ToString() +
                   dni_lector_62_BP +
                   fecha_62_BP.ToString("O", CultureInfo.InvariantCulture) +
                   aceptada_62_BP.ToString() +
                   completada_62_BP.ToString() +
                   (fecha_completada_62_BP.HasValue
                       ? fecha_completada_62_BP.Value.ToString("O", CultureInfo.InvariantCulture)
                       : string.Empty);
        }
    }
}
