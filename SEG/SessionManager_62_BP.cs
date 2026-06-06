using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG.Permisos;
using SEG.Permisos_62_BP;

namespace SEG_62_BP
{
    public class SessionManager_62_BP
    {
        private SessionManager_62_BP() { }
        private static SessionManager_62_BP instancia_62_BP;
        private static readonly object _lock = new object();

        public static SessionManager_62_BP GetInstancia_62_BP()
        {
            if (instancia_62_BP == null)
            {
                lock (_lock)
                {
                    if (instancia_62_BP == null)
                    {
                        instancia_62_BP = new SessionManager_62_BP();
                    }
                }
            }
            return instancia_62_BP;
        }

        private Usuario_62_BP usuarioLogueado_62_BP;

		public Usuario_62_BP UsuarioLogueado_62_BP
        {
			get { return usuarioLogueado_62_BP; }
			private set { usuarioLogueado_62_BP = value; }
		}
        public void Login_62_BP(Usuario_62_BP usuario)
        {
            if (usuarioLogueado_62_BP == null)
            {
                usuarioLogueado_62_BP = usuario;
            }
            else
            {
                throw new Exception("Ya hay un usuario Logueado");
            }
        }

        public void Logout_62_BP()
        {
            if (usuarioLogueado_62_BP != null)
            {
                usuarioLogueado_62_BP = null;
            }
            else
            {
                throw new Exception("No hay un usuario Logueado");
            }
        }

        public bool TienePermiso_62_BP(int idPatente)
        {
            foreach (ComponentePermiso_62_BP permiso in UsuarioLogueado_62_BP.Rol_62_BP.Permisos_62_BP)
            {
                if (TienePermisoRecursivo_62_BP(permiso, idPatente))
                    return true;
            }

            return false;
        }
        public bool TienePermisoRecursivo_62_BP(ComponentePermiso_62_BP componente, int idPatente)
        {
            if (componente is Patente_62_BP patente)
                return patente.Id_62_BP == idPatente;

            if (componente is Familia_62_BP familia)
            {
                foreach (ComponentePermiso_62_BP hijo in familia.Hijos_62_BP)
                {
                    if (TienePermisoRecursivo_62_BP(hijo, idPatente))
                        return true;
                }
            }
            else if (componente is Rol_62_BP rol)
            {
                foreach (ComponentePermiso_62_BP permiso in rol.Permisos_62_BP)
                {
                    if (TienePermisoRecursivo_62_BP(permiso, idPatente))
                        return true;
                }
            }

            return false;
        }
    }
}
