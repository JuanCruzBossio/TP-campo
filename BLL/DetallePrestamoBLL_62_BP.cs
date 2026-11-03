using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class DetallePrestamoBLL_62_BP
    {
        private DetallePrestamoMapper_62_BP _detallePrestamoMapper_62_BP = new DetallePrestamoMapper_62_BP();

        public bool AgregarDetallePrestamo_62_BP(DetallePrestamoBE_62_BP detallePrestamo)
        {
            bool resultado = false;

            try
            {
                resultado = _detallePrestamoMapper_62_BP.AgregarDetallePrestamo_62_BP(detallePrestamo);
            }
            catch
            {
                throw new Exception("No se pudo agregar el detalle del préstamo.");
            }

            return resultado;
        }

        public bool ModificarDetallePrestamo_62_BP(DetallePrestamoBE_62_BP detallePrestamo)
        {
            bool resultado = false;

            try
            {
                resultado = _detallePrestamoMapper_62_BP.ModificarDetallePrestamo_62_BP(detallePrestamo);
            }
            catch
            {
                throw new Exception("No se pudo modificar el detalle del préstamo.");
            }

            return resultado;
        }

        public DetallePrestamoBE_62_BP BuscarDetallePrestamo_62_BP(int idLibro = 0, int idPrestamo = 0)
        {
            DetallePrestamoBE_62_BP detallePrestamo = null;

            try
            {
                detallePrestamo = _detallePrestamoMapper_62_BP.BuscarDetallePrestamo_62_BP(idLibro, idPrestamo);
            }
            catch
            {
                throw new Exception("No se pudo buscar el detalle del préstamo.");
            }

            return detallePrestamo;
        }
    }
}
