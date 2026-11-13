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
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();

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
                if (filasAfectadas > 0 && multa.pagada_62_BP)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "Pago de Multa N: " + multa.id_multa_62_BP,
                        2);
                }
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

        public List<MultaBE_62_BP> BuscarMultas_62_BP(int? idMulta = null, int? idPrestamo = null, string dni = null)
        {
            try
            {
                return _multaMapper_62_BP.BuscarMultas_62_BP(idMulta, idPrestamo, dni);
            }
            catch
            {
                throw new Exception("No se pudieron buscar las multas.");
            }
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

        public int GenerarMultasPorDevolucion_62_BP(
            PrestamoBE_62_BP prestamo,
            List<DetallePrestamoBE_62_BP> detalles)
        {
            if (prestamo == null || detalles == null)
            {
                throw new ArgumentNullException();
            }

            int multasGeneradas = 0;
            foreach (DetallePrestamoBE_62_BP detalle in detalles)
            {
                if (detalle.perdido_62_BP)
                {
                    MultaBE_62_BP multaLibroPerdido = new MultaBE_62_BP
                    {
                        id_prestamo_62_BP = prestamo.id_prestamo_62_BP,
                        monto_62_BP = 20000,
                        pagada_62_BP = false,
                        motivo_62_BP = "Libro perdido. ID libro: " + detalle.id_libro_62_BP
                    };

                    if (AgregarMulta_62_BP(multaLibroPerdido) <= 0)
                    {
                        throw new Exception("No se pudo generar la multa por libro perdido.");
                    }

                    multasGeneradas++;
                }
            }

            int diasRetraso = (DateTime.Now.Date - prestamo.fecha_limite_62_BP.Date).Days;
            if (diasRetraso > 0)
            {
                MultaBE_62_BP multaRetraso = new MultaBE_62_BP
                {
                    id_prestamo_62_BP = prestamo.id_prestamo_62_BP,
                    monto_62_BP = diasRetraso * 500,
                    pagada_62_BP = false,
                    motivo_62_BP = "Devolución fuera de término. Días de retraso: " + diasRetraso
                };

                if (AgregarMulta_62_BP(multaRetraso) <= 0)
                {
                    throw new Exception("No se pudo generar la multa por devolución fuera de término.");
                }

                multasGeneradas++;
            }

            return multasGeneradas;
        }
    }
}
