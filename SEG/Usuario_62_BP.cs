using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG
{
    public class Usuario_62_BP
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string contrasenaHasheada;

		public string ContrasenaHasheada
        {
			get { return contrasenaHasheada; }
			set { contrasenaHasheada = value; }
		}

		private int intentosLogin;

		public int IntentosLogin
		{
			get { return intentosLogin; }
			set { intentosLogin = value; }
		}

		private int rol;

		public int Rol
		{
			get { return rol; }
			set { rol = value; }
		}

	}
}
