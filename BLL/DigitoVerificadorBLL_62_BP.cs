using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEG;
using SEG.Permisos_62_BP;
using SEG_62_BP;

namespace BLL
{
    public class DigitoVerificadorBLL_62_BP
    {
        private DigitoVerificadorDAL_62_BP _digitoVerificadorDAL_62_BP = new DigitoVerificadorDAL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        public int AltaDVV_62_BP(string tabla, string dvv)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = _digitoVerificadorDAL_62_BP.AltaDVV_62_BP(tabla, dvv);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo dar de alta el DVV.");
            }
            return filasAfectadas;
        }
        public int ActualizarDVV_62_BP(string tabla, string dvv)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = _digitoVerificadorDAL_62_BP.ActualizarDVV_62_BP(tabla, dvv);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo Actualizar el DVV.");
            }
            return filasAfectadas;
        }
        public string CalcularDVV_62_BP(string tabla)
        {
            string dvv = "";
            try
            {
                string stringdvv = _digitoVerificadorDAL_62_BP.ObtenerStringDVV_62_BP(tabla);
                dvv = _encriptacionSEG.EncriptarConSHA256_62_BP(stringdvv);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo Obtener el DVV.");
            }
            return dvv;
        }
        public int ActualizarTablaDVV_62_BP(string tabla)
        {
            int filasAfectadas = 0;
            try
            {
                string dvv = CalcularDVV_62_BP(tabla);
                filasAfectadas = ActualizarDVV_62_BP(tabla, dvv);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo Actualizar el DVV.");
            }
            return filasAfectadas;
        }
        public DigitoVerificadorVertical_62_BP BuscarDVV_62_BP(string tabla)
        {
            DigitoVerificadorVertical_62_BP dvv = null;
            try
            {
                dvv = _digitoVerificadorDAL_62_BP.BuscarDVV_62_BP(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo Actualizar el DVV.");
            }
            return dvv;
        }
        public List<DigitoVerificadorVertical_62_BP> BuscarErrorDVV_62_BP()
        {
            List<DigitoVerificadorVertical_62_BP> errores = new List<DigitoVerificadorVertical_62_BP>();
            try
            {
                List<DigitoVerificadorVertical_62_BP> lista = _digitoVerificadorDAL_62_BP.BuscarDVV_62_BP();
                foreach (var dvv in lista)
                {
                    if (CalcularDVV_62_BP(dvv.Tabla_62_BP) != dvv.DVV_62_BP)
                    {
                        errores.Add(dvv);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo Revisar tablas DVV.");
            }
            return errores;
        }
    }
}
