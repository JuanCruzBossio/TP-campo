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
    public class LectorBLL_62_BP
    {
        private LectorMapper_62_BP _lectorMapper_62_BP = new LectorMapper_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG_62_BP = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorBLL_62_BP = new DigitoVerificadorBLL_62_BP();

        public int AgregarLector_62_BP(LectorBE_62_BP lector)
        {
            int filasAfectadas = 0;

            try
            {
                LectorBE_62_BP lectorExistente = _lectorMapper_62_BP.BuscarLector_62_BP(dni: lector.dni_62_BP);

                if (lectorExistente != null)
                {
                    throw new Exception("Ya existe un lector con el DNI: " + lector.dni_62_BP);
                }

                filasAfectadas = _lectorMapper_62_BP.AgregarLector_62_BP(lector);
                if (filasAfectadas > 0)
                {
                    ActualizarLectorDVH_62_BP(lector.dni_62_BP);
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                        "Lector",
                        "AgregarLector",
                        "Alta de Lector DNI: " + lector.dni_62_BP,
                        1);
                }
            }
            catch
            {
                throw;
            }

            return filasAfectadas;
        }

        public int ModificarLector_62_BP(LectorBE_62_BP lector)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _lectorMapper_62_BP.ModificarLector_62_BP(lector);
                if (filasAfectadas > 0)
                {
                    ActualizarLectorDVH_62_BP(lector.dni_62_BP);
                }
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

        public int ActualizarLectorDVH_62_BP(string dni)
        {
            LectorBE_62_BP lector = _lectorMapper_62_BP.BuscarLector_62_BP(dni: dni);
            if (lector == null) return 0;

            string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(lector.ObtenerCadenaDVH_62_BP());
            int filas = _lectorMapper_62_BP.ActualizarDVH_62_BP(dni, dvh);
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Lector_62_BP");
            return filas;
        }

        public int RecalcularDVH_62_BP()
        {
            int filas = 0;
            foreach (LectorBE_62_BP lector in _lectorMapper_62_BP.BuscarLectores_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(lector.ObtenerCadenaDVH_62_BP());
                filas += _lectorMapper_62_BP.ActualizarDVH_62_BP(lector.dni_62_BP, dvh);
            }
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Lector_62_BP");
            return filas;
        }

        public List<LectorBE_62_BP> BuscarErrorDVH_62_BP()
        {
            List<LectorBE_62_BP> errores = new List<LectorBE_62_BP>();
            foreach (LectorBE_62_BP lector in _lectorMapper_62_BP.BuscarLectores_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(lector.ObtenerCadenaDVH_62_BP());
                if (dvh != _lectorMapper_62_BP.BuscarDVH_62_BP(lector.dni_62_BP)) errores.Add(lector);
            }
            return errores;
        }
    }
}
