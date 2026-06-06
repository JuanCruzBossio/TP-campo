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
using TP_campo;

namespace TP_campo_62_BP
{
    public partial class Menu_62_BP : Form
    {
        public Menu_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();
        private string _nombreUsuario_62_BP = "";

        //Eventos
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

        private void Menu_62_BP_Load(object sender, EventArgs e)
        {
            _nombreUsuario_62_BP = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Nombre_62_BP + " "+ SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Apellido_62_BP;
            labelNombre.Text = "Usuario Logueado: "+ _nombreUsuario_62_BP;
            AplicarPermisos_62_BP();
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FamiliaGUI_62_BP FamiliaForm = new FamiliaGUI_62_BP();
            FamiliaForm.MdiParent = this;
            FamiliaForm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolGUI_62_BP RolForm = new RolGUI_62_BP();
            RolForm.MdiParent = this;
            RolForm.Show();
        }
        private void AplicarPermisos_62_BP()
        {
            SessionManager_62_BP session = SessionManager_62_BP.GetInstancia_62_BP();

            usuariosToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(1) ||
                session.TienePermiso_62_BP(2) ||
                session.TienePermiso_62_BP(3) ||
                session.TienePermiso_62_BP(4);

            rolesToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(5) ||
                session.TienePermiso_62_BP(6) ||
                session.TienePermiso_62_BP(7);

            familiasToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(8) ||
                session.TienePermiso_62_BP(9) ||
                session.TienePermiso_62_BP(10);

            backupToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(11);

            restoreToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(12);

            bitacoraToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(13);

            digitoVerificadorToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(14);

            reLoginToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(15);

            cambiarClaveToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(16);

            cambiarIdiomaToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(17);
        }
    }
}
