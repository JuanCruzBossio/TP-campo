using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL_62_BP;
using DAL;
using SEG.Permisos_62_BP;
using SEG_62_BP;

namespace BLL
{
    public class FamiliaBLL_62_BP
    {
        private FamiliaDAL_62_BP _familiaDAL_62_BP = new FamiliaDAL_62_BP();
        private PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorDAL = new DigitoVerificadorBLL_62_BP();

        public int Alta_62_BP(Familia_62_BP familia)
        {
            int filasAfectadas = 0;

            try
            {
                int id  = _familiaDAL_62_BP.Alta_62_BP(familia);

                if (id == 0)
                    throw new Exception("No se pudo obtener el ID de la familia.");
                
                foreach (var hijo in familia.Hijos_62_BP)
                    {
                        if (hijo is Familia_62_BP familiaHija)
                        {
                            AgregarFamilia_62_BP(id, familiaHija.Id_62_BP);
                        }
                        else if (hijo is Patente_62_BP patente)
                        {
                            AgregarPatente_62_BP(id, patente.Id_62_BP);
                        }
                    }
                ActualizarFamiliaDVH_62_BP(id);
                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Alta de Familia " + familia.Nombre_62_BP, 1);
            }
            catch
            {
                throw new Exception("No se pudo crear la familia.");
            }

            return filasAfectadas;
        }

        public int Modificar_62_BP(Familia_62_BP familia)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = _familiaDAL_62_BP.Modificar_62_BP(familia);
                if (filasAfectadas > 0)
                {
                    ActualizarFamiliaDVH_62_BP(familia.Id_62_BP);
                }
                _familiaDAL_62_BP.BorrarRelacionesFamiliaPatente_62_BP(familia.Id_62_BP);
                _familiaDAL_62_BP.BorrarRelacionesFamiliaFamilia_62_BP(familia.Id_62_BP);

                foreach (var hijo in familia.Hijos_62_BP)
                {
                    if (hijo is Familia_62_BP fam)
                        AgregarFamilia_62_BP(familia.Id_62_BP, fam.Id_62_BP);

                    else if (hijo is Patente_62_BP pat)
                        AgregarPatente_62_BP(familia.Id_62_BP, pat.Id_62_BP);
                }
                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Modificación de Familia " + familia.Nombre_62_BP, 2);
            }
            catch
            {
                throw new Exception("No se pudo modificar la familia.");
            }
            return filasAfectadas;
        }

        public int Baja_62_BP(Familia_62_BP familia)
        {
            int filasAfectadas = 0;

            try
            {
                _familiaDAL_62_BP.BorrarRelacionesRolFamilia_62_BP(familia.Id_62_BP);

                _familiaDAL_62_BP.BorrarRelacionesFamiliaPatente_62_BP(familia.Id_62_BP);

                _familiaDAL_62_BP.BorrarRelacionesFamiliaFamilia_62_BP(familia.Id_62_BP);

                filasAfectadas =_familiaDAL_62_BP.Baja_62_BP(familia.Id_62_BP);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Baja de Familia " + familia.Nombre_62_BP,3);
                }
            }
            catch
            {
                throw new Exception(
                    "No se pudo Borrar la familia.");
            }

            return filasAfectadas;
        }

        public Familia_62_BP BuscarFamilia_62_BP(int id, string nombre = null)
        {
            Familia_62_BP familia = null;
            try
            {
                familia = _familiaDAL_62_BP.BuscarFamilia_62_BP(id, nombre);
                if (familia != null)
                {
                    List<Patente_62_BP> patentes = _patenteBLL_62_BP.BuscarPatentesPorFamilia_62_BP(id);
                    if(patentes != null)
                    {
                        foreach (Patente_62_BP patente in patentes)
                        {
                            familia.Agregar_62_BP(patente);
                        }
                    }
                    List<Familia_62_BP> familiasHijas = _familiaDAL_62_BP.BuscarFamiliasPorFamilia_62_BP(id);
                    if (familiasHijas != null)
                    {
                        foreach (Familia_62_BP familiaHija in familiasHijas)
                        {
                            Familia_62_BP familiaHijaCompleta = BuscarFamilia_62_BP(familiaHija.Id_62_BP, null);

                            if (familiaHijaCompleta != null)
                            {
                                familia.Agregar_62_BP(familiaHijaCompleta);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("No se pudo obtener la familia.");
            }
            return familia;
        }

        public List<Familia_62_BP> BuscarFamilias_62_BP()
        {
            List<Familia_62_BP> listaCompleta = new List<Familia_62_BP>();
            try
            {
                List<Familia_62_BP> listaFamilias = _familiaDAL_62_BP.BuscarFamilias_62_BP();

                if (listaFamilias != null)
                {
                    foreach (Familia_62_BP familia in listaFamilias)
                    {
                        Familia_62_BP familiaCompleta = BuscarFamilia_62_BP(familia.Id_62_BP, null);

                        if (familiaCompleta != null)
                        {
                            listaCompleta.Add(familiaCompleta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener las familias");
            }
            return listaCompleta;
        }
        public List<Familia_62_BP> BuscarFamiliasPorRol_62_BP(int idRol)
        {
            List<Familia_62_BP> listaCompleta = new List<Familia_62_BP>();
            try
            {
                List<Familia_62_BP> listaFamilias = _familiaDAL_62_BP.BuscarFamiliasPorRol_62_BP(idRol);

                if (listaFamilias != null)
                {
                    foreach (Familia_62_BP familia in listaFamilias)
                    {
                        Familia_62_BP familiaCompleta = BuscarFamilia_62_BP(familia.Id_62_BP, null);

                        if (familiaCompleta != null)
                        {
                            listaCompleta.Add(familiaCompleta);
                        }
                    }
                }

                return listaCompleta;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener las familias");
            }
        }
        public int AgregarPatente_62_BP(int idFamilia, int idPatente)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _familiaDAL_62_BP.AgregarPatente_62_BP(idFamilia, idPatente);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Asignación de Patente a Familia", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo agregar la patente a la familia.");
            }

            return filasAfectadas;
        }

        public int QuitarPatente_62_BP(int idFamilia, int idPatente)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _familiaDAL_62_BP.QuitarPatente_62_BP(idFamilia, idPatente);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Desasignación de Patente de Familia", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo quitar la patente de la familia.");
            }

            return filasAfectadas;
        }

        public int AgregarFamilia_62_BP(int idFamiliaPadre, int idFamiliaHija)
        {
            int filasAfectadas = 0;

            try
            {
                if (idFamiliaPadre == idFamiliaHija)
                    throw new Exception("Una familia no puede contenerse a sí misma.");

                filasAfectadas = _familiaDAL_62_BP.AgregarFamilia_62_BP(idFamiliaPadre, idFamiliaHija);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Asignación de Familia a Familia", 2);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Una familia no puede contenerse a sí misma.")
                    throw;

                throw new Exception("No se pudo agregar la familia.");
            }

            return filasAfectadas;
        }

        public int QuitarFamilia_62_BP(int idFamiliaPadre, int idFamiliaHija)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _familiaDAL_62_BP.QuitarFamilia_62_BP(idFamiliaPadre, idFamiliaHija);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Desasignación de Familia de Familia", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo quitar la familia.");
            }

            return filasAfectadas;
        }
        public int ActualizarFamiliaDVH_62_BP(int id)
        {
            int filasAfectadas = 0;
            Familia_62_BP familia = null;
            try
            {
                familia = _familiaDAL_62_BP.BuscarFamilia_62_BP(id: id);
                if (familia != null)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(familia.ObtenerCadenaDVH_62_BP());
                    filasAfectadas = _familiaDAL_62_BP.ActualizarDVH_62_BP(id, dvh);
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Familia_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int RecalcularFamiliasDVH_62_BP()
        {
            int filasAfectadas = 0;
            try
            {
                List<Familia_62_BP> familias = _familiaDAL_62_BP.BuscarFamilias_62_BP();
                if (familias != null)
                {
                    foreach (var familia in familias)
                    {
                        string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(familia.ObtenerCadenaDVH_62_BP());
                        _familiaDAL_62_BP.ActualizarDVH_62_BP(familia.Id_62_BP, dvh);
                        filasAfectadas++;
                    }
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Familia_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public List<Familia_62_BP> BuscarErrorDVH_62_BP()
        {
            List<Familia_62_BP> errores = new List<Familia_62_BP>();
            try
            {
                List<Familia_62_BP> lista = BuscarFamilias_62_BP();
                foreach (var familia in lista)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(familia.ObtenerCadenaDVH_62_BP());
                    if (dvh != _familiaDAL_62_BP.BuscarDVH_62_BP(familia.Id_62_BP))
                    {
                        errores.Add(familia);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al revisar Datos DVH Familias.");
            }
            return errores;
        }
    }
}
