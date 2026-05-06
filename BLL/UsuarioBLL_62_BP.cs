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
    }
}
