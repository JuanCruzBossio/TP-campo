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
using SEG;

namespace TP_campo
{
    public partial class Login_62_BP : Form
    {
        public Login_62_BP()
        {
            InitializeComponent();
        }
        private UsuarioBLL_62_BP _usuarioBLL = new UsuarioBLL_62_BP();

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBoxNombre.Text;
                string contrasena = textBoxContrasena.Text;

                if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(contrasena))
                {
                    Usuario_62_BP usuario = _usuarioBLL.Login(nombre, contrasena);

                    if (usuario != null)
                    {
                        Menu_62_BP menu = new Menu_62_BP();
                        menu.Show();
                        textBoxNombre.Clear();
                        textBoxContrasena.Clear();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan ingresar datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el inicio de sesión: " + ex.Message);
            }
        }
    }
}
