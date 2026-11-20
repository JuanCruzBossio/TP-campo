using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using DIGITO_62_BP;

namespace BE_62_BP
{
    public class PrestamoBE_62_BP : IDigitoVerificadorHorizontal_62_BP
    {
        public int id_prestamo_62_BP { get; set; }
        public string dni_lector_62_BP { get; set; }
        public DateTime fecha_prestamo_62_BP { get; set; }
        public DateTime fecha_limite_62_BP { get; set; }
        public bool finalizado_62_BP { get; set; }

        public string ObtenerCadenaDVH_62_BP()
        {
            return id_prestamo_62_BP.ToString() +
                   dni_lector_62_BP +
                   fecha_prestamo_62_BP.ToString("O", CultureInfo.InvariantCulture) +
                   fecha_limite_62_BP.ToString("O", CultureInfo.InvariantCulture) +
                   finalizado_62_BP.ToString();
        }
    }
}
