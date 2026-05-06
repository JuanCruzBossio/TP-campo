using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace TP_campo
{
    public partial class Login_62_BP : Form
    {
        public Login_62_BP()
        {
            InitializeComponent();
        }
        private UsuarioBLL_62_BP _bitacoraBLL = new UsuarioBLL_62_BP();

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string contrasena = textBoxContrasena.Text;
            if (nombre != "" && contrasena != "")
            {
                _bitacoraBLL.Login(nombre, contrasena);
            }
            else
            {
                MessageBox.Show("Faltan ingresar datos");
            }
        }
    }
}
