using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG_62_BP.Observer;

namespace SEG_62_BP.Singleton
{
  
    public class Sesion_62_BP
    {
        
        public Idioma_62_BP IdiomaActual_62_BP { get; set; }

        public Usuario_62_BP UsuarioLogueado_62_BP { get; set; }

        private List<IObservadorIdioma_62_BP> _observadores_62_BP;

        public Sesion_62_BP()
        {
            _observadores_62_BP = new List<IObservadorIdioma_62_BP>();
            IdiomaActual_62_BP = new Idioma_62_BP("es-AR", new Dictionary<string, string>());
            UsuarioLogueado_62_BP = null;
        }

        public void SuscribirObservador_62_BP(IObservadorIdioma_62_BP observador_62_BP)
        {
            if (observador_62_BP == null)
                throw new ArgumentNullException(nameof(observador_62_BP), "El observador no puede ser nulo.");

            // Verificar si ya existe para evitar duplicados
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


        public void IniciarSesion_62_BP(Usuario_62_BP usuario_62_BP)
        {
            if (usuario_62_BP == null)
                throw new ArgumentNullException(nameof(usuario_62_BP), "El usuario no puede ser nulo.");

            UsuarioLogueado_62_BP = usuario_62_BP;
        }


        public void CerrarSesion_62_BP()
        {
            UsuarioLogueado_62_BP = null;
            _observadores_62_BP.Clear();
        }

        public bool EstaAutenticado_62_BP()
        {
            return UsuarioLogueado_62_BP != null;
        }
    }
}