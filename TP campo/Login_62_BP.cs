using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_62_BP;
using SEG_62_BP;

namespace TP_campo_62_BP
{//Prueba de commit
    public partial class Login_62_BP : Form
    {
        public Login_62_BP()
        {
            InitializeComponent();
        }
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textBoxLogin.Text;
                string contrasena = textBoxContrasena.Text;

                if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(contrasena))
                {
                    Usuario_62_BP usuario = _usuarioBLL_62_BP.Login_62_BP(login, contrasena);

                    if (usuario != null)
                    {
                        textBoxLogin.Clear();
                        textBoxContrasena.Clear();
                        checkBoxPassword.Checked = false;
                        textBoxContrasena.PasswordChar = '*';
                        if (usuario.ForzarContrasenaNueva_62_BP)
                        {
                            CambiarClaveGUI_62_BP cambiarClaveGUI = new CambiarClaveGUI_62_BP();
                            cambiarClaveGUI.Show();
                            this.Hide();
                        }
                        else
                        {
                            Menu_62_BP menu = new Menu_62_BP();
                            menu.Show();
                            this.Hide();
                        }
                        
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

        private void Login_62_BP_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                textBoxContrasena.PasswordChar = '\0';
            }
            else
            {
                textBoxContrasena.PasswordChar = '*';
            }
        }
    }
}
