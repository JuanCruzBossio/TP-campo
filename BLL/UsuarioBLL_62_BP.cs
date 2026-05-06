using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEG;

namespace BLL
{
    public class UsuarioBLL_62_BP
    {

        private UsuarioDAL_62_BP _usuarioDAL = new UsuarioDAL_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL = new BitacoraBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        public int Alta(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Alta(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Alta de Usuario", 1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return filasAfectadas;
        }
        public int BajaLogica(Usuario_62_BP usuario)
        {

            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.BajaLogica(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Baja Logica de Usuario", 2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return filasAfectadas;
        }
        public int Modificar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Modificar(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Modificacion de Usuario", 1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return filasAfectadas;
        }
        public int Habilitar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Habilitar(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Habilitación de Usuario", 2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return filasAfectadas;
        }

        public Usuario_62_BP Login(string nombre, string contrasena)
        {
            try
            {
                Usuario_62_BP usuario = _usuarioDAL.BuscarUsuarioPorNombre(nombre);

                if (usuario == null)
                    throw new Exception("Usuario no encontrado.");

                if (usuario.IntentosLogin >= 3)
                    throw new Exception("Usuario bloqueado por demasiados intentos fallidos.");

                string contrasenaHasheada = _encriptacionSEG.EncriptarConSHA256(contrasena);
                if (usuario.ContrasenaHasheada != contrasenaHasheada)
                {
                    int intentosRestantes = 3 - (usuario.IntentosLogin + 1);
                    throw new Exception($"Contraseña incorrecta. Intentos restantes: {intentosRestantes}");
                }

                SessionManager_62_BP.GetInstancia().Login(usuario);

                _bitacoraBLL.Alta("Login de Usuario", 1);

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Logout()
        {
            try
            {
                Usuario_62_BP usuarioActual = SessionManager_62_BP.GetInstancia().UsuarioLogueado;

                if (usuarioActual == null) {
                    throw new Exception("No hay un usuario logueado.");
                }

                _bitacoraBLL.Alta("Logout de Usuario",1);

                SessionManager_62_BP.GetInstancia().Logout();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
