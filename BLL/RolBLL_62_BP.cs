using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_62_BP;
using DAL;
using SEG.Permisos_62_BP;
using SEG_62_BP;

namespace BLL
{
    public class RolBLL_62_BP
    {
        private RolDAL_62_BP _rolDAL_62_BP = new RolDAL_62_BP();
        private FamiliaBLL_62_BP _familiaBLL_62_BP = new FamiliaBLL_62_BP();
        private PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorDAL = new DigitoVerificadorBLL_62_BP();

        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();

        public int Alta_62_BP(Rol_62_BP rol)
        {
            int filasAfectadas = 0;

            try
            {
                int id = _rolDAL_62_BP.Alta_62_BP(rol);

                if (id == 0) {

                    throw new Exception("No se pudo obtener el ID del rol.");
                }

                foreach (var hijo in rol.Permisos_62_BP)
                {
                    if (hijo is Familia_62_BP familia)
                    {
                        AgregarFamilia_62_BP(id, familia.Id_62_BP);
                    }
                    else if (hijo is Patente_62_BP patente)
                    {
                        AgregarPatente_62_BP(id, patente.Id_62_BP);
                    }
                }

                filasAfectadas = 1;
                ActualizarRolDVH_62_BP(id);
                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Alta de Rol " + rol.Nombre_62_BP, 1);
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
                    ActualizarRolDVH_62_BP(rol.Id_62_BP);
                }
                _rolDAL_62_BP.BorrarRelacionesRolFamilia_62_BP(rol.Id_62_BP);
                _rolDAL_62_BP.BorrarRelacionesRolPatente_62_BP(rol.Id_62_BP);

                foreach (var hijo in rol.Permisos_62_BP)
                {
                    if (hijo is Familia_62_BP familia) {
                        AgregarFamilia_62_BP(rol.Id_62_BP, familia.Id_62_BP);
                    }

                    else if (hijo is Patente_62_BP patente) {
                        AgregarPatente_62_BP(rol.Id_62_BP, patente.Id_62_BP);
                    }
                }

                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Modificación de Rol " + rol.Nombre_62_BP, 2);
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
                bool usuariosAsignados = _rolDAL_62_BP.TieneUsuariosAsignados_62_BP(rol.Id_62_BP);

                if (usuariosAsignados)
                {
                    throw new Exception("El rol tiene  usuarios asignados.");
                }

                _rolDAL_62_BP.BorrarRelacionesRolFamilia_62_BP(rol.Id_62_BP);

                _rolDAL_62_BP.BorrarRelacionesRolPatente_62_BP(rol.Id_62_BP);

                filasAfectadas = _rolDAL_62_BP.Baja_62_BP(rol.Id_62_BP);

                if (filasAfectadas > 0)
                {
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Rol_62_BP");
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
                            rol.Agregar_62_BP(patente);
                        }
                    }
                    List<Familia_62_BP> familiasHijas = _familiaBLL_62_BP.BuscarFamiliasPorRol_62_BP(id);
                    if (familiasHijas != null)
                    {
                        foreach (Familia_62_BP familiaHija in familiasHijas)
                        {
                            Familia_62_BP familiaHijaCompleta = _familiaBLL_62_BP.BuscarFamilia_62_BP(familiaHija.Id_62_BP, null);

                            if (familiaHijaCompleta != null)
                            {
                                rol.Agregar_62_BP(familiaHijaCompleta);
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
        public int ActualizarRolDVH_62_BP(int id)
        {
            int filasAfectadas = 0;
            Rol_62_BP rol = null;
            try
            {
                rol = _rolDAL_62_BP.BuscarRol_62_BP(id: id);
                if (rol != null)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(rol.ObtenerCadenaDVH_62_BP());
                    filasAfectadas = _rolDAL_62_BP.ActualizarDVH_62_BP(id, dvh);
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Rol_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int RecalcularRolesDVH_62_BP()
        {
            int filasAfectadas = 0;
            try
            {
                List<Rol_62_BP> roles = _rolDAL_62_BP.BuscarRoles_62_BP();
                if (roles != null)
                {
                    foreach (var rol in roles)
                    {
                        string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(rol.ObtenerCadenaDVH_62_BP());
                        _rolDAL_62_BP.ActualizarDVH_62_BP(rol.Id_62_BP, dvh);
                        filasAfectadas++;
                    }
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Rol_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public List<Rol_62_BP> BuscarErrorDVH_62_BP()
        {
            List<Rol_62_BP> errores = new List<Rol_62_BP>();
            try
            {
                List<Rol_62_BP> lista = _rolDAL_62_BP.BuscarRoles_62_BP();
                foreach (var rol in lista)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(rol.ObtenerCadenaDVH_62_BP());
                    if (dvh != _rolDAL_62_BP.BuscarDVH_62_BP(rol.Id_62_BP))
                    {
                        errores.Add(rol);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al revisar Datos DVH Roles.");
            }
            return errores;
        }
    }
}
