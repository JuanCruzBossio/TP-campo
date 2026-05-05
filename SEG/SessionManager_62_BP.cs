using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace SEG
{
    public class SessionManager_62_BP
    {
        private static SessionManager_62_BP instancia;

        public static SessionManager_62_BP GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new SessionManager_62_BP();
            }
            return instancia;
        }

        private Usuario_62_BP usuarioLogueado;

		public Usuario_62_BP UsuarioLogueado
        {
			get { return usuarioLogueado; }
			set { usuarioLogueado = value; }
		}

        public void Login(Usuario_62_BP usuario)
        {
            if (usuarioLogueado == null)
            {
                try
                {
                    UsuarioDAL_62_BP usuarioDal = new UsuarioDAL_62_BP();
                    var tabla = usuarioDal.BuscarUsuarioPorNombre(usuario.Nombre);
                    Usuario_62_BP usuarioEncontrado = new Usuario_62_BP();
                    foreach (DataRow fila in tabla.Rows)
                    {
                        usuarioEncontrado.Id = Convert.ToInt32(fila["id"]);

                        usuarioEncontrado.Nombre = fila["nombre"].ToString();

                        usuarioEncontrado.ContrasenaHasheada = fila["contrasenaHasheada"].ToString();

                        usuarioEncontrado.IntentosLogin = Convert.ToInt32(fila["intentosLogin"]);

                        usuarioEncontrado.Rol = Convert.ToInt32(fila["rol"]);
                    }
                    if (usuarioEncontrado.IntentosLogin >= 3)
                    {
                        new Exception("Limite de Intentos Superado");
                    }
                    else if (usuarioEncontrado.ContrasenaHasheada != usuario.ContrasenaHasheada)
                    {
                        new Exception("Usuario o contraseña Incorrecta");
                    }
                    else if (usuarioEncontrado.ContrasenaHasheada == usuario.ContrasenaHasheada)
                    {
                        usuarioLogueado = usuario;
                    }
                }
                catch (Exception ex) {
                    new Exception (ex.ToString());
                }
                
            }
            else
            {
                new Exception("Ya hay un usuario Logueado");
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
                new Exception("No hay un usuario Logueado");
            }
        }
    }
}
