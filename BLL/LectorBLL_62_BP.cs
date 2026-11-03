using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class LectorBLL_62_BP
    {
        private LectorMapper_62_BP _lectorMapper_62_BP = new LectorMapper_62_BP();

        public int AgregarLector_62_BP(LectorBE_62_BP lector)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _lectorMapper_62_BP.AgregarLector_62_BP(lector);
            }
            catch
            {
                throw new Exception("No se pudo agregar el lector.");
            }

            return filasAfectadas;
        }

        public int ModificarLector_62_BP(LectorBE_62_BP lector)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _lectorMapper_62_BP.ModificarLector_62_BP(lector);
            }
            catch
            {
                throw new Exception("No se pudo modificar el lector.");
            }

            return filasAfectadas;
        }

        public LectorBE_62_BP BuscarLector_62_BP(string dni = null, string nombre = null)
        {
            LectorBE_62_BP lector = null;

            try
            {
                lector = _lectorMapper_62_BP.BuscarLector_62_BP(dni, nombre);
            }
            catch
            {
                throw new Exception("No se pudo buscar el lector.");
            }

            return lector;
        }
    }
}
