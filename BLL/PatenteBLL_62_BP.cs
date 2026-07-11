using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEG.Permisos_62_BP;
using SEG_62_BP;

namespace BLL
{
    public class PatenteBLL_62_BP
    {
        private PatenteDAL_62_BP _patenteDAL_62_BP = new PatenteDAL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorDAL = new DigitoVerificadorBLL_62_BP();


        public Patente_62_BP BuscarPatente_62_BP(int? id = null, string nombre = null)
        {
            Patente_62_BP patente = null;

            try
            {
                patente = _patenteDAL_62_BP.BuscarPatente_62_BP(id, nombre);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo obtener la patente.");
            }

            return patente;
        }

        public List<Patente_62_BP> BuscarPatentes_62_BP()
        {
            List<Patente_62_BP> lista = null;

            try
            {
                lista = _patenteDAL_62_BP.BuscarPatentes_62_BP();

            }
            catch (Exception)
            {
                throw new Exception("No se pudieron obtener las patentes.");
            }

            return lista;
        }
        public List<Patente_62_BP> BuscarPatentesPorFamilia_62_BP(int idFamilia)
        {
            List<Patente_62_BP> lista = null;

            try
            {
                lista = _patenteDAL_62_BP.BuscarPatentesPorFamilia_62_BP(idFamilia);

                if (lista == null)
                {
                    lista = new List<Patente_62_BP>();
                }
            }
            catch (Exception)
            {
                throw new Exception("No se pudieron obtener las patentes de la familia.");
            }

            return lista;
        }
        public List<Patente_62_BP> BuscarPatentesPorRol_62_BP(int idRol)
        {
            List<Patente_62_BP> lista = null;

            try
            {
                lista = _patenteDAL_62_BP.BuscarPatentesPorRol_62_BP(idRol);

                if (lista == null)
                {
                    lista = new List<Patente_62_BP>();
                }
            }
            catch (Exception)
            {
                throw new Exception("No se pudieron obtener las patentes del rol.");
            }

            return lista;
        }
        public int ActualizarPatenteDVH_62_BP(int id)
        {
            int filasAfectadas = 0;
            Patente_62_BP patente = null;
            try
            {
                patente = _patenteDAL_62_BP.BuscarPatente_62_BP(id);
                if (patente != null)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(patente.ObtenerCadenaDVH_62_BP());
                    filasAfectadas = _patenteDAL_62_BP.ActualizarDVH_62_BP(id, dvh);
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Patente_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int RecalcularDVH_62_BP()
        {
            int filasAfectadas = 0;
            try
            {
                List<Patente_62_BP> patentes = _patenteDAL_62_BP.BuscarPatentes_62_BP();
                if (patentes != null)
                {
                    foreach (var patente in patentes)
                    {
                        string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(patente.ObtenerCadenaDVH_62_BP());
                        _patenteDAL_62_BP.ActualizarDVH_62_BP(patente.Id_62_BP, dvh);
                        filasAfectadas++;
                    }
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Patente_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public List<Patente_62_BP> BuscarErrorDVH_62_BP()
        {
            List<Patente_62_BP> errores = new List<Patente_62_BP>();
            try
            {
                List<Patente_62_BP> lista = BuscarPatentes_62_BP();
                foreach (var patente in lista)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(patente.ObtenerCadenaDVH_62_BP());
                    if (dvh != _patenteDAL_62_BP.BuscarDVH_62_BP(patente.Id_62_BP))
                    {
                        errores.Add(patente);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al revisar Datos DVH Patentes.");
            }
            return errores;
        }
    }
}
