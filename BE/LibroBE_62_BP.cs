using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIGITO_62_BP;

namespace BE_62_BP
{
    public class LibroBE_62_BP : IDigitoVerificadorHorizontal_62_BP
    {
        public int id_libro_62_BP { get; set; }
        public string titulo_62_BP { get; set; }
        public string autor_62_BP { get; set; }
        public string isbn_62_BP { get; set; }
        public string genero_62_BP { get; set; }
        public int numero_volumen_62_BP { get; set; }
        public bool prestado_62_BP { get; set; }

        public string ObtenerCadenaDVH_62_BP()
        {
            return id_libro_62_BP.ToString() +
                   titulo_62_BP +
                   autor_62_BP +
                   isbn_62_BP +
                   genero_62_BP +
                   numero_volumen_62_BP.ToString() +
                   prestado_62_BP.ToString();
        }
    }
}
