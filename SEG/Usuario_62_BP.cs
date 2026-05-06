using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG
{
    public class Usuario_62_BP
    {
        private string dni;
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string rol;
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string contrasena;
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        private bool bloqueo;
        public bool Bloqueo
        {
            get { return bloqueo; }
            set { bloqueo = value; }
        }

        private bool activo;
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }

}
