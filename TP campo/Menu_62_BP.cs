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
    public partial class Menu_62_BP : Form
    {
        public Menu_62_BP()
        {
            InitializeComponent();
        }
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioGUI_62_BP usuarioGUI = new UsuarioGUI_62_BP();
            usuarioGUI.MdiParent = this;
            usuarioGUI.Show();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarClaveGUI_62_BP cambiarClaveGUI = new CambiarClaveGUI_62_BP();
            cambiarClaveGUI.MdiParent = this;
            cambiarClaveGUI.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _usuarioBLL_62_BP.Logout_62_BP();

                MessageBox.Show("Sesión cerrada con éxito.");

                Form login = Application.OpenForms["Login_62_BP"];

                login.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar sesión: " + ex.Message);
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Bitacora_62_BP bitacoraForm = new Bitacora_62_BP();
            bitacoraForm.MdiParent = this;
            bitacoraForm.Show();        
        }

        private void reLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login_62_BP LoginForm = new Login_62_BP();
            LoginForm.MdiParent = this;
            LoginForm.Show();
        }
    }
}
