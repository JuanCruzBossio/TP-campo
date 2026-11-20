using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using DIGITO_62_BP;

namespace BE_62_BP
{
    public class LectorBE_62_BP : IDigitoVerificadorHorizontal_62_BP
    {
        public string dni_62_BP { get; set; }
        public string nombre_62_BP { get; set; }
        public string apellido_62_BP { get; set; }
        public DateTime? fecha_nacimiento_62_BP { get; set; }

        public string ObtenerCadenaDVH_62_BP()
        {
            return dni_62_BP +
                   nombre_62_BP +
                   apellido_62_BP +
                   (fecha_nacimiento_62_BP.HasValue
                       ? fecha_nacimiento_62_BP.Value.ToString("O", CultureInfo.InvariantCulture)
                       : string.Empty);
        }
    }
}
