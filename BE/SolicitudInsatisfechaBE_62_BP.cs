using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_62_BP
{
    public class SolicitudInsatisfechaBE_62_BP
    {
        public int id_solicitud_62_BP { get; set; }
        public int id_libro_62_BP { get; set; }
        public string dni_lector_62_BP { get; set; }
        public DateTime fecha_62_BP { get; set; }
        public bool aceptada_62_BP { get; set; } = false;
        public bool completada_62_BP { get; set; } = false;
        public DateTime? fecha_completada_62_BP { get; set; }
    }
}
