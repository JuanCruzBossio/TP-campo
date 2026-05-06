using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG
{
    public class SessionManager_62_BP
    {
        private SessionManager_62_BP() { }
        private static SessionManager_62_BP instancia;
        private static readonly object _lock = new object();

        public static SessionManager_62_BP GetInstancia()
        {
            if (instancia == null)
            {
                lock (_lock)
                {
                    if (instancia == null)
                    {
                        instancia = new SessionManager_62_BP();
                    }
                }
            }
            return instancia;
        }

        private Usuario_62_BP usuarioLogueado;

		public Usuario_62_BP UsuarioLogueado
        {
			get { return usuarioLogueado; }
			private set { usuarioLogueado = value; }
		}

        public void Login(Usuario_62_BP usuario)
        {
            if (usuarioLogueado == null)
            {
                usuarioLogueado = usuario;
            }
            else
            {
                throw new Exception("Ya hay un usuario Logueado");
            }
        }

        public void Logout()
        {
            if (usuarioLogueado != null)
            {
                usuarioLogueado = null;
            }
            else
            {
                throw new Exception("No hay un usuario Logueado");
            }
        }
    }
}
