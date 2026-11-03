using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class PrestamoBLL_62_BP
    {
        private PrestamoMapper_62_BP _prestamoMapper_62_BP = new PrestamoMapper_62_BP();

        public int AgregarPrestamo_62_BP(PrestamoBE_62_BP prestamo)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _prestamoMapper_62_BP.AgregarPrestamo_62_BP(prestamo);
            }
            catch
            {
                throw new Exception("No se pudo agregar el préstamo.");
            }

            return filasAfectadas;
        }

        public int ModificarPrestamo_62_BP(PrestamoBE_62_BP prestamo)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _prestamoMapper_62_BP.ModificarPrestamo_62_BP(prestamo);
            }
            catch
            {
                throw new Exception("No se pudo modificar el préstamo.");
            }

            return filasAfectadas;
        }

        public PrestamoBE_62_BP BuscarPrestamo_62_BP(int? id = null, string dniLector = null)
        {
            PrestamoBE_62_BP prestamo = null;

            try
            {
                prestamo = _prestamoMapper_62_BP.BuscarPrestamo_62_BP(id, dniLector);
            }
            catch
            {
                throw new Exception("No se pudo buscar el préstamo.");
            }

            return prestamo;
        }
    }
}
