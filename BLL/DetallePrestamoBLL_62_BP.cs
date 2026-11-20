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
    public class DetallePrestamoBLL_62_BP
    {
        private DetallePrestamoMapper_62_BP _detallePrestamoMapper_62_BP = new DetallePrestamoMapper_62_BP();
        private Encriptacion_62_BP _encriptacionSEG_62_BP = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorBLL_62_BP = new DigitoVerificadorBLL_62_BP();

        public bool AgregarDetallePrestamo_62_BP(DetallePrestamoBE_62_BP detalle)
        {
            try
            {
                bool agregado = _detallePrestamoMapper_62_BP.AgregarDetallePrestamo_62_BP(detalle);
                if (agregado) ActualizarDetallePrestamoDVH_62_BP(detalle.id_libro_62_BP, detalle.id_prestamo_62_BP);
                return agregado;
            }
            catch
            {
                throw new Exception("No se pudo agregar el detalle del prestamo.");
            }
        }

        public bool ModificarDetallePrestamo_62_BP(DetallePrestamoBE_62_BP detalle)
        {
            try
            {
                bool modificado = _detallePrestamoMapper_62_BP.ModificarDetallePrestamo_62_BP(detalle);
                if (modificado) ActualizarDetallePrestamoDVH_62_BP(detalle.id_libro_62_BP, detalle.id_prestamo_62_BP);
                return modificado;
            }
            catch
            {
                throw new Exception("No se pudo modificar el detalle del prestamo.");
            }
        }

        public DetallePrestamoBE_62_BP BuscarDetallePrestamo_62_BP(int idLibro = 0, int idPrestamo = 0)
        {
            try
            {
                return _detallePrestamoMapper_62_BP.BuscarDetallePrestamo_62_BP(idLibro, idPrestamo);
            }
            catch
            {
                throw new Exception("No se pudo buscar el detalle del prestamo.");
            }
        }

        public List<DetallePrestamoBE_62_BP> BuscarDetallesPorPrestamo_62_BP(int idPrestamo)
        {
            try
            {
                return _detallePrestamoMapper_62_BP.BuscarDetallesPorPrestamo_62_BP(idPrestamo);
            }
            catch
            {
                throw new Exception("No se pudieron buscar los libros del prestamo.");
            }
        }

        public int ActualizarDetallePrestamoDVH_62_BP(int idLibro, int idPrestamo)
        {
            DetallePrestamoBE_62_BP detalle = _detallePrestamoMapper_62_BP.BuscarDetallePrestamo_62_BP(idLibro, idPrestamo);
            if (detalle == null) return 0;
            string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(detalle.ObtenerCadenaDVH_62_BP());
            int filas = _detallePrestamoMapper_62_BP.ActualizarDVH_62_BP(idLibro, idPrestamo, dvh);
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("DetallePrestamo_62_BP");
            return filas;
        }

        public int RecalcularDVH_62_BP()
        {
            int filas = 0;
            foreach (DetallePrestamoBE_62_BP detalle in _detallePrestamoMapper_62_BP.BuscarTodosLosDetalles_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(detalle.ObtenerCadenaDVH_62_BP());
                filas += _detallePrestamoMapper_62_BP.ActualizarDVH_62_BP(detalle.id_libro_62_BP, detalle.id_prestamo_62_BP, dvh);
            }
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("DetallePrestamo_62_BP");
            return filas;
        }

        public List<DetallePrestamoBE_62_BP> BuscarErrorDVH_62_BP()
        {
            List<DetallePrestamoBE_62_BP> errores = new List<DetallePrestamoBE_62_BP>();
            foreach (DetallePrestamoBE_62_BP detalle in _detallePrestamoMapper_62_BP.BuscarTodosLosDetalles_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(detalle.ObtenerCadenaDVH_62_BP());
                if (dvh != _detallePrestamoMapper_62_BP.BuscarDVH_62_BP(detalle.id_libro_62_BP, detalle.id_prestamo_62_BP)) errores.Add(detalle);
            }
            return errores;
        }
    }
}
