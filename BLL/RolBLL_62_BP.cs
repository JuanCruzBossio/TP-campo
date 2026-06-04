using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_62_BP;
using DAL;
using SEG.Permisos_62_BP;

namespace BLL
{
    public class RolBLL_62_BP
    {
        private RolDAL_62_BP _rolDAL_62_BP = new RolDAL_62_BP();
        private FamiliaBLL_62_BP familiaBLL_62_BP = new FamiliaBLL_62_BP();
        private PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();

        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();

        public int Alta_62_BP(Rol_62_BP rol)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.Alta_62_BP(rol);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Alta de Rol " + rol.Nombre_62_BP, 1);
                }
            }
            catch
            {
                throw new Exception("No se pudo crear el rol.");
            }

            return filasAfectadas;
        }

        public int Modificar_62_BP(Rol_62_BP rol)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.Modificar_62_BP(rol);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Modificación de Rol " + rol.Nombre_62_BP, 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo modificar el rol.");
            }

            return filasAfectadas;
        }

        public int Baja_62_BP(Rol_62_BP rol)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.Baja_62_BP(rol.Id_62_BP);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Baja de Rol " + rol.Nombre_62_BP, 3);
                }
            }
            catch
            {
                throw new Exception("No se pudo eliminar el rol.");
            }

            return filasAfectadas;
        }

        public Rol_62_BP BuscarRol_62_BP(int? id = null, string nombre = null)
        {
            Rol_62_BP rol = null;

            try
            {
                rol = _rolDAL_62_BP.BuscarRol_62_BP(id, nombre);
            }
            catch
            {
                throw new Exception("No se pudo obtener el rol.");
            }

            return rol;
        }
        public Rol_62_BP BuscarRol_62_BP(int id, string nombre = null)
        {
            Rol_62_BP rol = null;

            try
            {
                rol = _rolDAL_62_BP.BuscarRol_62_BP(id, nombre);
                if (rol != null)
                {
                    List<Patente_62_BP> patentes = _patenteBLL_62_BP.BuscarPatentesPorRol_62_BP(id);
                    if (patentes != null)
                    {
                        foreach (Patente_62_BP patente in patentes)
                        {
                            rol.AgregarPermiso_62_BP(patente);
                        }
                    }
                    List<Familia_62_BP> familiasHijas = familiaBLL_62_BP.BuscarFamiliasPorRol_62_BP(id);
                    if (familiasHijas != null)
                    {
                        foreach (Familia_62_BP familiaHija in familiasHijas)
                        {
                            Familia_62_BP familiaHijaCompleta = familiaBLL_62_BP.BuscarFamilia_62_BP(familiaHija.Id_62_BP, null);

                            if (familiaHijaCompleta != null)
                            {
                                rol.AgregarPermiso_62_BP(familiaHijaCompleta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener el rol con sus permisos.");
            }

            return rol;
        }
        public List<Rol_62_BP> BuscarRoles_62_BP()
        {
            List<Rol_62_BP> listaCompleta = new List<Rol_62_BP>();
            try
            {
                List<Rol_62_BP> listaRoles = _rolDAL_62_BP.BuscarRoles_62_BP();

                if (listaRoles != null)
                {
                    foreach (Rol_62_BP rol in listaRoles)
                    {
                        Rol_62_BP rolCompleto = BuscarRol_62_BP(rol.Id_62_BP, null);

                        if (rolCompleto != null)
                        {
                            listaCompleta.Add(rolCompleto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener los roles.");
            }
            return listaCompleta;
        }

        public int AgregarPatente_62_BP(int idRol, int idPatente)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.AgregarPatente_62_BP(idRol, idPatente);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Asignación de Patente a Rol", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo agregar la patente al rol.");
            }

            return filasAfectadas;
        }

        public int QuitarPatente_62_BP(int idRol, int idPatente)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.QuitarPatente_62_BP(idRol, idPatente);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Desasignación de Patente de Rol", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo quitar la patente del rol.");
            }

            return filasAfectadas;
        }

        public int AgregarFamilia_62_BP(int idRol, int idFamilia)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.AgregarFamilia_62_BP(idRol, idFamilia);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Asignación de Familia a Rol", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo agregar la familia al rol.");
            }

            return filasAfectadas;
        }

        public int QuitarFamilia_62_BP(int idRol, int idFamilia)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _rolDAL_62_BP.QuitarFamilia_62_BP(idRol, idFamilia);

                if (filasAfectadas > 0)
                {
                    _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Desasignación de Familia de Rol", 2);
                }
            }
            catch
            {
                throw new Exception("No se pudo quitar la familia del rol.");
            }

            return filasAfectadas;
        }
    }
}
