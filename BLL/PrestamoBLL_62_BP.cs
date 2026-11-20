using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;
using BLL;
using SEG_62_BP;

namespace BLL_62_BP
{
    public class PrestamoBLL_62_BP
    {
        private PrestamoMapper_62_BP _prestamoMapper_62_BP = new PrestamoMapper_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG_62_BP = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorBLL_62_BP = new DigitoVerificadorBLL_62_BP();

        public int AgregarPrestamo_62_BP(PrestamoBE_62_BP prestamo)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _prestamoMapper_62_BP.AgregarPrestamo_62_BP(prestamo);
                if (filasAfectadas > 0)
                {
                    ActualizarPrestamoDVH_62_BP(filasAfectadas);
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "Prestamo",
                        "AgregarPrestamo",
                        "Registro de Prestamo N: " + filasAfectadas,
                        1);
                }
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
                if (filasAfectadas > 0)
                {
                    ActualizarPrestamoDVH_62_BP(prestamo.id_prestamo_62_BP);
                }
            }
            catch
            {
                throw new Exception("No se pudo modificar el préstamo.");
            }

            return filasAfectadas;
        }

        public int FinalizarPrestamo_62_BP(int idPrestamo)
        {
            try
            {
                int filasAfectadas = _prestamoMapper_62_BP.FinalizarPrestamo_62_BP(idPrestamo);
                if (filasAfectadas > 0)
                {
                    ActualizarPrestamoDVH_62_BP(idPrestamo);
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "Prestamo",
                        "FinalizarPrestamo",
                        "Devolucion de Prestamo N: " + idPrestamo,
                        2);
                }

                return filasAfectadas;
            }
            catch
            {
                throw new Exception("No se pudo finalizar el préstamo.");
            }
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

        public List<PrestamoBE_62_BP> BuscarPrestamosPorDNI_62_BP(string dni)
        {
            List<PrestamoBE_62_BP> prestamos = null;

            try
            {
                prestamos = _prestamoMapper_62_BP.BuscarPrestamosPorDNI_62_BP(dni);
            }
            catch
            {
                throw new Exception("No se pudieron buscar los préstamos del lector.");
            }

            return prestamos;
        }

        public List<PrestamoBE_62_BP> BuscarPrestamos_62_BP(int? idPrestamo = null, string dni = null, bool soloActivos = false)
        {
            try
            {
                return _prestamoMapper_62_BP.BuscarPrestamos_62_BP(idPrestamo, dni, soloActivos);
            }
            catch
            {
                throw new Exception("No se pudieron buscar los préstamos.");
            }
        }

        public int ContarPrestamosActivos_62_BP(string dni)
        {
            int cantidad = 0;

            try
            {
                cantidad = _prestamoMapper_62_BP.ContarPrestamosActivos_62_BP(dni);
            }
            catch
            {
                throw new Exception("No se pudo contar los préstamos activos del lector.");
            }

            return cantidad;
        }

        public int MarcarLibrosPrestados_62_BP(int idPrestamo)
        {
            LibroBLL_62_BP libroBLL = new LibroBLL_62_BP();
            List<int> idsLibros;

            try
            {
                idsLibros = _prestamoMapper_62_BP.ObtenerIdsLibrosPorPrestamo_62_BP(idPrestamo);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la lista de libros del préstamo: " + ex.Message);
            }

            int total = 0;
            foreach (int idLibro in idsLibros)
            {
                total += libroBLL.MarcarPrestado_62_BP(idLibro);
            }

            return total;
        }

        public int MarcarLibrosDevolvidos_62_BP(int idPrestamo)
        {
            LibroBLL_62_BP libroBLL = new LibroBLL_62_BP();
            List<int> idsLibros;

            try
            {
                idsLibros = _prestamoMapper_62_BP.ObtenerIdsLibrosPorPrestamo_62_BP(idPrestamo);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la lista de libros del préstamo: " + ex.Message);
            }

            int total = 0;
            foreach (int idLibro in idsLibros)
            {
                total += libroBLL.MarcarDisponible_62_BP(idLibro);
            }

            return total;
        }

        public int ActualizarPrestamoDVH_62_BP(int idPrestamo)
        {
            PrestamoBE_62_BP prestamo = _prestamoMapper_62_BP.BuscarPrestamo_62_BP(id: idPrestamo);
            if (prestamo == null) return 0;
            string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(prestamo.ObtenerCadenaDVH_62_BP());
            int filas = _prestamoMapper_62_BP.ActualizarDVH_62_BP(idPrestamo, dvh);
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Prestamo_62_BP");
            return filas;
        }

        public int RecalcularDVH_62_BP()
        {
            int filas = 0;
            foreach (PrestamoBE_62_BP prestamo in _prestamoMapper_62_BP.BuscarPrestamos_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(prestamo.ObtenerCadenaDVH_62_BP());
                filas += _prestamoMapper_62_BP.ActualizarDVH_62_BP(prestamo.id_prestamo_62_BP, dvh);
            }
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Prestamo_62_BP");
            return filas;
        }

        public List<PrestamoBE_62_BP> BuscarErrorDVH_62_BP()
        {
            List<PrestamoBE_62_BP> errores = new List<PrestamoBE_62_BP>();
            foreach (PrestamoBE_62_BP prestamo in _prestamoMapper_62_BP.BuscarPrestamos_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(prestamo.ObtenerCadenaDVH_62_BP());
                if (dvh != _prestamoMapper_62_BP.BuscarDVH_62_BP(prestamo.id_prestamo_62_BP)) errores.Add(prestamo);
            }
            return errores;
        }
    }
}
