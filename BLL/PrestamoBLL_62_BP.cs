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

        public int FinalizarPrestamo_62_BP(int idPrestamo)
        {
            try
            {
                return _prestamoMapper_62_BP.FinalizarPrestamo_62_BP(idPrestamo);
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
    }
}
