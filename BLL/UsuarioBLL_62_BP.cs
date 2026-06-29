using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL_62_BP;
using SEG;
using SEG_62_BP;

namespace BLL_62_BP
{
    public class UsuarioBLL_62_BP
    {

        private UsuarioDAL_62_BP _usuarioDAL = new UsuarioDAL_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorDAL = new DigitoVerificadorBLL_62_BP();
        private RolBLL_62_BP _rolBLL = new RolBLL_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL = new BitacoraBLL_62_BP();
        private Encriptacion_62_BP _encriptacionSEG = new Encriptacion_62_BP();
        private IdiomaBLL_62_BP _idiomaBLL_62_BP = new IdiomaBLL_62_BP();
        public int Alta_62_BP(Usuario_62_BP usuario)
        {
            var dni = 0;
            if (usuario.Idioma_62_BP <= 0)
            {
                usuario.Idioma_62_BP = IdiomaBLL_62_BP.IdiomaEspanol_62_BP;
            }
            usuario.Contrasena_62_BP = _encriptacionSEG.EncriptarConSHA256_62_BP(usuario.Nombre_62_BP + usuario.Apellido_62_BP);
            try
            {
                dni = _usuarioDAL.Alta_62_BP(usuario);
                if (dni > 0)
                {
                    ActualizarUsuarioDVH_62_BP(dni.ToString());
                    _bitacoraBLL.RegistrarBitacora_62_BP("Alta de Usuario " + usuario.Login_62_BP, 1);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    string error = ex.Message.ToLower();

                    if (error.Contains("login_62_BP"))
                    {
                        throw new Exception("Ya existe un usuario con ese Login.");
                    }

                    if (error.Contains("dni_62_BP"))
                    {
                        throw new Exception("Ya existe un usuario con ese DNI.");
                    }

                    throw new Exception("Ya existe un usuario con los datos ingresados.");
                    throw;
                }
            }
            return dni;
        }
        public int Activar_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Activar_62_BP(usuario);
                if (filasAfectadas > 0)
                {
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    _bitacoraBLL.RegistrarBitacora_62_BP("Activación de Usuario " + usuario.Login_62_BP, 2);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int Desactivar_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Desactivar_62_BP(usuario);
                if (filasAfectadas > 0)
                {
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    _bitacoraBLL.RegistrarBitacora_62_BP("Desactivación de Usuario " + usuario.Login_62_BP, 2);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int Bloquear_62_BP(string login)
        {
            var filasAfectadas = 0;
            try
            {

                filasAfectadas = _usuarioDAL.Bloquear_62_BP(login);
                if (filasAfectadas > 0)
                {
                    Usuario_62_BP usuario = _usuarioDAL.BuscarUsuario_62_BP(login: login);
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    _bitacoraBLL.RegistrarBitacora_62_BP("Bloqueo de Usuario " + login, 3, usuario.Dni_62_BP);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int Desbloquear_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                usuario.Contrasena_62_BP = _encriptacionSEG.EncriptarConSHA256_62_BP(usuario.Nombre_62_BP + usuario.Apellido_62_BP);
                filasAfectadas = _usuarioDAL.Desbloquear_62_BP(usuario);
                if (filasAfectadas > 0)
                {
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    _bitacoraBLL.RegistrarBitacora_62_BP("Desbloqueo de Usuario " + usuario.Login_62_BP, 3);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int Modificar_62_BP(Usuario_62_BP usuario)
        {
            var filasAfectadas = 0;
            try
            {
                filasAfectadas = _usuarioDAL.Modificar_62_BP(usuario);
                if (filasAfectadas > 0)
                {
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    _bitacoraBLL.RegistrarBitacora_62_BP("Modificacion de Usuario " + usuario.Login_62_BP, 1);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    string error = ex.Message.ToLower();

                    if (error.Contains("login_62_BP"))
                    {
                        throw new Exception("Ya existe un usuario con ese Login.");
                    }

                    if (error.Contains("dni_62_BP"))
                    {
                        throw new Exception("Ya existe un usuario con ese DNI.");
                    }

                    throw new Exception("Error al modificar Datos");
                    throw;
                }
            }
            return filasAfectadas;
        }

        public Usuario_62_BP Buscar_por_DNI_62_BP(string dni)
        {
            Usuario_62_BP persona = null;
            try
            {
                persona = _usuarioDAL.BuscarUsuario_62_BP(dni: dni);
                if (persona != null)
                {
                    //_bitacoraBLL.Alta("Se busco usuario por DNI " + dni, 4);
                    //No consideramos acorde mantener un registro de la busqueda de usuario
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return persona;
        }

        public Usuario_62_BP Login_62_BP(string login, string contrasena)
        {
            try
            {
                Usuario_62_BP usuario = _usuarioDAL.BuscarUsuario_62_BP(login: login);

                if (usuario == null)
                {
                    throw new Exception("Usuario no registrado.");
                }
                if (!usuario.Activo_62_BP)
                {
                    throw new Exception("Usuario Desactivado.");
                }
                if (usuario.Bloqueo_62_BP)
                {
                    throw new Exception("Usuario Bloqueado.");
                }
                string contrasenaHasheada = _encriptacionSEG.EncriptarConSHA256_62_BP(contrasena);

                if (usuario.Contrasena_62_BP == contrasenaHasheada)
                {
                    if (usuario.IntentosLogin_62_BP > 0)
                    {
                        usuario.IntentosLogin_62_BP = 0;
                        _usuarioDAL.GuardarIntentosLogin_62_BP(usuario);
                        ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    }
                    usuario.Rol_62_BP = _rolBLL.BuscarRol_62_BP(usuario.IdRol_62_BP);
                    SessionManager_62_BP.GetInstancia_62_BP().Login_62_BP(usuario);
                    AplicarIdiomaUsuario_62_BP(usuario);
                    _bitacoraBLL.RegistrarBitacora_62_BP("Login de Usuario " + usuario.Login_62_BP, 1);

                    return usuario;
                }
                else
                {
                    usuario.IntentosLogin_62_BP++;

                    if (usuario.IntentosLogin_62_BP >= 3)
                    {
                        Bloquear_62_BP(login);
                        throw new Exception("Usuario Bloqueado por intentos de Login incorrectos.");
                    }

                    _usuarioDAL.GuardarIntentosLogin_62_BP(usuario);
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    throw new Exception("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Logout_62_BP()
        {
            try
            {
                Usuario_62_BP usuarioActual = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP;

                if (usuarioActual == null) {
                    throw new Exception("No hay un usuario logueado.");
                }
                var dniUsuario = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Dni_62_BP;
                SessionManager_62_BP.GetInstancia_62_BP().Logout_62_BP();
                AplicarIdiomaDefault_62_BP();

                _bitacoraBLL.RegistrarBitacora_62_BP("Logout de Usuario",1, dniUsuario);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Usuario_62_BP> TraerTodosUsuarios_62_BP()
        {
            try
            {
                return _usuarioDAL.TraerTodosUsuarios_62_BP();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int CambiarContrasena_62_BP(string claveVieja, string claveNueva)
        {
            var filasAfectadas = 0;
            try
            {
                string claveViejaHasheada = _encriptacionSEG.EncriptarConSHA256_62_BP(claveVieja);

                if (SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Contrasena_62_BP != claveViejaHasheada)
                {
                    throw new Exception("La contraseña actual no es correcta.");
                }

                Usuario_62_BP usuario = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP;
                usuario.Contrasena_62_BP = _encriptacionSEG.EncriptarConSHA256_62_BP(claveNueva);
                filasAfectadas = _usuarioDAL.CambiarContrasena_62_BP(usuario);

                if (filasAfectadas > 0)
                {
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                    SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Contrasena_62_BP = usuario.Contrasena_62_BP;
                    _bitacoraBLL.RegistrarBitacora_62_BP("Cambio de contraseña del Usuario " + usuario.Login_62_BP, 3);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public int CambiarIdioma_62_BP(int idioma)
        {
            int filasAfectadas = 0;
            try
            {
                Usuario_62_BP usuario = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP;

                if (usuario == null)
                {
                    throw new Exception("No hay un usuario logueado.");
                }

                int idiomaNormalizado = idioma <= 0 ? IdiomaBLL_62_BP.IdiomaEspanol_62_BP : idioma;
                filasAfectadas = _usuarioDAL.CambiarIdioma_62_BP(usuario.Dni_62_BP, idiomaNormalizado);

                if (filasAfectadas > 0)
                {
                    usuario.Idioma_62_BP = idiomaNormalizado;
                    ActualizarUsuarioDVH_62_BP(usuario.Dni_62_BP);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        private void AplicarIdiomaUsuario_62_BP(Usuario_62_BP usuario)
        {
            try
            {
                string codigoIdioma = _idiomaBLL_62_BP.ObtenerCodigoIdioma_62_BP(usuario.Idioma_62_BP);
                SessionManager_62_BP.GetInstancia_62_BP()
                    .CambiarIdioma_62_BP(_idiomaBLL_62_BP.CargarIdioma_62_BP(codigoIdioma));
            }
            catch
            {
                SessionManager_62_BP.GetInstancia_62_BP()
                    .CambiarIdioma_62_BP(_idiomaBLL_62_BP.CargarIdioma_62_BP(IdiomaBLL_62_BP.CodigoEspanol_62_BP));
            }
        }

        private void AplicarIdiomaDefault_62_BP()
        {
            try
            {
                SessionManager_62_BP.GetInstancia_62_BP()
                    .CambiarIdioma_62_BP(_idiomaBLL_62_BP.CargarIdioma_62_BP(IdiomaBLL_62_BP.CodigoEspanol_62_BP));
            }
            catch
            {
            }
        }
        public int ActualizarUsuarioDVH_62_BP(string dni)
        {
            int filasAfectadas = 0;
            Usuario_62_BP usuario = null;
            try
            {
                usuario = _usuarioDAL.BuscarUsuario_62_BP(dni: dni);
                if (usuario != null)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(usuario.ObtenerCadenaDVH_62_BP());
                    filasAfectadas = _usuarioDAL.ActualizarDVH_62_BP(dni, dvh);
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Usuario_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public int RecalcularUsuariosDVH_62_BP()
        {
            int filasAfectadas = 0;
            try
            {
                List<Usuario_62_BP> usuarios = _usuarioDAL.BuscarUsuarios_62_BP();
                if (usuarios != null)
                {
                    foreach (var usuario in usuarios)
                    {
                        string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(usuario.ObtenerCadenaDVH_62_BP());
                        _usuarioDAL.ActualizarDVH_62_BP(usuario.Dni_62_BP, dvh);
                        filasAfectadas++;
                    }
                    _digitoVerificadorDAL.ActualizarTablaDVV_62_BP("Usuario_62_BP");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }
        public List<Usuario_62_BP> BuscarErrorDVH_62_BP()
        {
            List<Usuario_62_BP> errores = new List<Usuario_62_BP>();
            try
            {
                List<Usuario_62_BP> lista = TraerTodosUsuarios_62_BP();
                foreach (var usuario in lista)
                {
                    string dvh = _encriptacionSEG.EncriptarConSHA256_62_BP(usuario.ObtenerCadenaDVH_62_BP());
                    if (dvh != _usuarioDAL.BuscarDVH_62_BP(usuario.Dni_62_BP))
                    {
                        errores.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al revisar Datos DVH Usuarios.");
            }
            return errores;
        }
    }
}
