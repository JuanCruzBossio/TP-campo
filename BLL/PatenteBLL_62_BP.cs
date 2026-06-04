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

                if (lista == null)
                {
                    lista = new List<Patente_62_BP>();
                }
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
    }
}
