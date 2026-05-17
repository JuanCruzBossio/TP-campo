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
    }
}
