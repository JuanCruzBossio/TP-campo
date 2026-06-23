using SEG.Permisos;
using SEG.Permisos_62_BP;
using SEG_62_BP.Observer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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


        // ==================== NUEVA PARTE PATRON OBSERVER PARA IDIOMA ====================

        public Idioma_62_BP IdiomaActual_62_BP { get; set; }
        private List<IObservadorIdioma_62_BP> _observadores_62_BP = new List<IObservadorIdioma_62_BP>();

        public void SuscribirObservador_62_BP(IObservadorIdioma_62_BP observador_62_BP)
        {
            if (observador_62_BP == null)
                throw new ArgumentNullException(nameof(observador_62_BP), "El observador no puede ser nulo.");

            if (!_observadores_62_BP.Contains(observador_62_BP))
            {
                _observadores_62_BP.Add(observador_62_BP);
            }
        }

        public void DesuscribirObservador_62_BP(IObservadorIdioma_62_BP observador_62_BP)
        {
            if (observador_62_BP == null)
                throw new ArgumentNullException(nameof(observador_62_BP), "El observador no puede ser nulo.");

            if (_observadores_62_BP.Contains(observador_62_BP))
            {
                _observadores_62_BP.Remove(observador_62_BP);
            }
        }

        public void CambiarIdioma_62_BP(Idioma_62_BP nuevoIdioma_62_BP)
        {
            if (nuevoIdioma_62_BP == null)
                throw new ArgumentNullException(nameof(nuevoIdioma_62_BP), "El idioma no puede ser nulo.");

            IdiomaActual_62_BP = nuevoIdioma_62_BP;


            NotificarObservadores_62_BP();
        }


        private void NotificarObservadores_62_BP()
        {

            var copiaObservadores_62_BP = new List<IObservadorIdioma_62_BP>(_observadores_62_BP);

            foreach (var observador_62_BP in copiaObservadores_62_BP)
            {
                try
                {
                    observador_62_BP.ActualizarIdioma_62_BP(IdiomaActual_62_BP);
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine($"Error notificando observador: {ex.Message}");
                }
            }
        }
    }
}



    

