using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace SEG
{
    public class UsuarioServicio_62_BP
    {
        private UsuarioDAL_62_BP _usuarioDAL = new UsuarioDAL_62_BP();
        public int Alta(Usuario_62_BP usuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@pass", usuario.ContrasenaHasheada),
                new SqlParameter("@rol", usuario.Rol)
            };

            return _usuarioDAL.Alta(parametros);
        }
        public int BajaLogica(Usuario_62_BP usuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", usuario.Id)
            };

            return _usuarioDAL.BajaLogica(parametros);
        }
        public int Modificar(Usuario_62_BP usuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", usuario.Id),
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@pass", usuario.ContrasenaHasheada),
                new SqlParameter("@rol", usuario.Rol)
            };

            return _usuarioDAL.Modificar(parametros);
        }
        public int Habilitar(Usuario_62_BP usuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id", usuario.Id)
            };

            return _usuarioDAL.Habilitar(parametros);
        }
    }
}
