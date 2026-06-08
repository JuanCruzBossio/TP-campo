using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG;
using SEG.Permisos_62_BP;

namespace SEG_62_BP
{
    public class Usuario_62_BP : IDigitoVerificadorHorizontal_62_BP
    {
        private string dni_62_BP;
        public string Dni_62_BP
        {
            get { return dni_62_BP; }
            set { dni_62_BP = value; }
        }

        private string apellido_62_BP;
        public string Apellido_62_BP
        {
            get { return apellido_62_BP; }
            set { apellido_62_BP = value; }
        }

        private string nombre_62_BP;
        public string Nombre_62_BP
        {
            get { return nombre_62_BP; }
            set { nombre_62_BP = value; }
        }

        private int idRol_62_BP;
        public int IdRol_62_BP
        {
            get { return idRol_62_BP; }
            set { idRol_62_BP = value; }
        }
        private Rol_62_BP rol_62_BP;
        public Rol_62_BP Rol_62_BP
        {
            get { return rol_62_BP; }
            set { rol_62_BP = value; }
        }

        private string email_62_BP;
        public string Email_62_BP
        {
            get { return email_62_BP; }
            set { email_62_BP = value; }
        }

        private string login_62_BP;
        public string Login_62_BP
        {
            get { return login_62_BP; }
            set { login_62_BP = value; }
        }

        private string contrasena_62_BP;
        public string Contrasena_62_BP
        {
            get { return contrasena_62_BP; }
            set { contrasena_62_BP = value; }
        }

        private bool bloqueo_62_BP;
        public bool Bloqueo_62_BP
        {
            get { return bloqueo_62_BP; }
            set { bloqueo_62_BP = value; }
        }

        private bool activo_62_BP;
        public bool Activo_62_BP
        {
            get { return activo_62_BP; }
            set { activo_62_BP = value; }
        }
        private int intentosLogin_62_BP;
        public int IntentosLogin_62_BP
        {
            get { return intentosLogin_62_BP; }
            set { intentosLogin_62_BP = value; }
        }
        private bool forzarContrasenaNueva_62_BP;
        public bool ForzarContrasenaNueva_62_BP
        {
            get { return forzarContrasenaNueva_62_BP; }
            set { forzarContrasenaNueva_62_BP = value; }
        }

        public string ObtenerCadenaDVH_62_BP()
        {
            return Dni_62_BP +
                   Apellido_62_BP +
                   Nombre_62_BP +
                   IdRol_62_BP.ToString() +
                   Email_62_BP +
                   Login_62_BP +
                   Contrasena_62_BP +
                   Bloqueo_62_BP.ToString() +
                   Activo_62_BP.ToString() +
                   IntentosLogin_62_BP.ToString() +
                   ForzarContrasenaNueva_62_BP.ToString();
        }
    }

}
