using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_campo
{
    public partial class Menu_62_BP : Form
    {
        public Menu_62_BP()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioGUI_62_BP usuarioGUI = new UsuarioGUI_62_BP();
            usuarioGUI.MdiParent = this;
            usuarioGUI.Show();
        }
    }
}
