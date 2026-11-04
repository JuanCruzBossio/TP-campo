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

        public List<MultaBE_62_BP> BuscarMultasPorIdPrestamo_62_BP(int idPrestamo)
        {
            List<MultaBE_62_BP> multas = null;

            try
            {
                multas = _multaMapper_62_BP.BuscarMultasPorIdPrestamo_62_BP(idPrestamo);
            }
            catch
            {
                throw new Exception("No se pudieron buscar las multas del préstamo.");
            }

            return multas;
        }

        public List<MultaBE_62_BP> ObtenerMultas_62_BP(string dni)
        {
            List<MultaBE_62_BP> multas = new List<MultaBE_62_BP>();

            try
            {
                PrestamoBLL_62_BP prestamoBLL = new PrestamoBLL_62_BP();

                List<PrestamoBE_62_BP> prestamos = prestamoBLL.BuscarPrestamosPorDNI_62_BP(dni);

                if (prestamos != null && prestamos.Count > 0)
                {
                    foreach (PrestamoBE_62_BP prestamo in prestamos)
                    {
                        List<MultaBE_62_BP> multasPrestamo = BuscarMultasPorIdPrestamo_62_BP(prestamo.id_prestamo_62_BP);

                        if (multasPrestamo != null && multasPrestamo.Count > 0)
                        {
                            multas.AddRange(multasPrestamo);
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("No se pudieron obtener las multas del lector.");
            }

            return multas;
        }
    }
}
