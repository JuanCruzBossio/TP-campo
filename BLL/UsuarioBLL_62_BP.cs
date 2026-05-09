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
            usuario.Contrasena = _encriptacionSEG.EncriptarConSHA256(usuario.Nombre + usuario.Apellido);
            try
            {
                filasAfectadas = _usuarioDAL.Alta(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Alta de Usuario " + usuario.Login, 1);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int Activar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Activar(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Activación de Usuario " + usuario.Login, 2);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int Desactivar(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Desactivar(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Desactivación de Usuario " + usuario.Login, 2);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int Bloquear(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Bloquear(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Bloqueo de Usuario " + usuario.Login, 3);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int Desbloquear(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Desbloquear(usuario);
                if (filasAfectadas > 0)
                {
                    _bitacoraBLL.Alta("Desbloqueo de Usuario " + usuario.Login, 3);
                }
            }
            catch (Exception ex)
            {
                throw;
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
                    _bitacoraBLL.Alta("Modificacion de Usuario " + usuario.Login, 1);
                }
            }
            catch (Exception ex)
            {
                throw;
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

                if (usuario.Activo == false)
                    throw new Exception("Usuario Desactivado.");

                if (usuario.Bloqueo == true)
                    throw new Exception("Usuario Bloqueado.");

                string contrasenaHasheada = _encriptacionSEG.EncriptarConSHA256(contrasena);
                if (usuario.Contrasena != contrasenaHasheada)
                {
                    //usuario.IntentosLogin ++;
                    //Modificar(usuario);
                    //int intentosRestantes = 3 - (usuario.IntentosLogin);
                    //throw new Exception($"Contraseña incorrecta. Intentos restantes: {intentosRestantes}");
                    throw new Exception("Contraseña incorrecta");
                }

                SessionManager_62_BP.GetInstancia().Login(usuario);

                _bitacoraBLL.Alta("Login de Usuario " + usuario.Login, 1);

                return usuario;
            }
            catch (Exception ex)
            {
                throw;
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
                var dniUsuario = SessionManager_62_BP.GetInstancia().UsuarioLogueado.Dni;
                SessionManager_62_BP.GetInstancia().Logout();

                _bitacoraBLL.Alta("Logout de Usuario",1, dniUsuario);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Usuario_62_BP> TraerTodosUsuarios()
        {
            try
            {
                return _usuarioDAL.TraerTodosUsuarios();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int CambiarContrasena(string claveVieja, string claveNueva)
        {
            var filasAfectadas = 0;
            try
            {
                string claveViejaHasheada = _encriptacionSEG.EncriptarConSHA256(claveVieja);

                if (SessionManager_62_BP.GetInstancia().UsuarioLogueado.Contrasena != claveViejaHasheada)
                {
                    throw new Exception("La contraseña actual no es correcta.");
                }

                Usuario_62_BP usuario = new Usuario_62_BP
                {
                    Dni = SessionManager_62_BP.GetInstancia().UsuarioLogueado.Dni,
                    Contrasena = _encriptacionSEG.EncriptarConSHA256(claveNueva),
                    Login = SessionManager_62_BP.GetInstancia().UsuarioLogueado.Login
                };
                filasAfectadas = _usuarioDAL.CambiarContrasena(usuario);

                if (filasAfectadas > 0)
                {
                    SessionManager_62_BP.GetInstancia().UsuarioLogueado.Contrasena = _encriptacionSEG.EncriptarConSHA256(claveNueva);
                    _bitacoraBLL.Alta("Cambio de contraseña del Usuario " + usuario.Login, 3);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

    }
}
