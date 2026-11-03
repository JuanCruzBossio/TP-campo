using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class MultaBLL_62_BP
    {
        private MultaMapper_62_BP _multaMapper_62_BP = new MultaMapper_62_BP();

        public int AgregarMulta_62_BP(MultaBE_62_BP multa)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _multaMapper_62_BP.AgregarMulta_62_BP(multa);
            }
            catch
            {
                throw new Exception("No se pudo agregar la multa.");
            }

            return filasAfectadas;
        }

        public int ModificarMulta_62_BP(MultaBE_62_BP multa)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _multaMapper_62_BP.ModificarMulta_62_BP(multa);
            }
            catch
            {
                throw new Exception("No se pudo modificar la multa.");
            }

            return filasAfectadas;
        }

        public MultaBE_62_BP BuscarMulta_62_BP(int? id = null, int idPrestamo = 0)
        {
            MultaBE_62_BP multa = null;

            try
            {
                multa = _multaMapper_62_BP.BuscarMulta_62_BP(id, idPrestamo);
            }
            catch
            {
                throw new Exception("No se pudo buscar la multa.");
            }

            return multa;
        }
    }
}
