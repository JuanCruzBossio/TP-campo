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

namespace TP_campo_62_BP
{
    public partial class CambiarClaveGUI_62_BP : Form
    {
        public CambiarClaveGUI_62_BP()
        {
            InitializeComponent();
        }

        //Variables
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();

        //Eventos
        private void buttonCambiarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                string antigua = textBoxContrasenaActual.Text;
                string nueva = textBoxContrasenaNueva.Text;
                string repetir = textBoxRepetirContrasenaNueva.Text;

                if (string.IsNullOrWhiteSpace(antigua) || string.IsNullOrWhiteSpace(nueva) || string.IsNullOrWhiteSpace(repetir))
                {
                    MessageBox.Show("Faltan completar datos.");
                    return;
                }
                if (nueva != repetir)
                {
                    MessageBox.Show("La nueva contraseña y su repetición no coinciden.");
                    return;
                }
                if (nueva == antigua)
                {
                    MessageBox.Show("La nueva contraseña no puede ser igual a la anterior.");
                    return;
                }
                int resultado = _usuarioBLL_62_BP.CambiarContrasena_62_BP(antigua, nueva);

                if (resultado > 0)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.");

                    textBoxContrasenaActual.Clear();
                    textBoxContrasenaNueva.Clear();
                    textBoxRepetirContrasenaNueva.Clear();
                    _usuarioBLL_62_BP.Logout_62_BP();
                    Form menu = Application.OpenForms["Menu_62_BP"];

                    if (menu != null)
                    {
                        menu.Close();
                    }

                    Form login = Application.OpenForms["Login_62_BP"];

                    if (login != null)
                    {
                        login.Show();
                    }

                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo realizar el cambio de contraseña.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar cambiar Constraseña : " + ex.Message);
            }
        }

        private void checkBoxContrasenaActual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxContrasenaActual.Checked)
            {
                textBoxContrasenaActual.PasswordChar = '\0';
            }
            else
            {
                textBoxContrasenaActual.PasswordChar = '*';
            }
        }

        private void checkBoxContrasenaNueva_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxContrasenaNueva.Checked)
            {
                textBoxContrasenaNueva.PasswordChar = '\0';
            }
            else
            {
                textBoxContrasenaNueva.PasswordChar = '*';
            }
        }

        private void checkBoxRepetirContrasenaNueva_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRepetirContrasenaNueva.Checked)
            {
                textBoxRepetirContrasenaNueva.PasswordChar = '\0';
            }
            else
            {
                textBoxRepetirContrasenaNueva.PasswordChar = '*';
            }
        }
    }
}
