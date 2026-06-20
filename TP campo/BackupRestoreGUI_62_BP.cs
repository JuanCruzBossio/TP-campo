using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL_62_BP;
using SEG_62_BP;

namespace TP_campo
{
    public partial class BackupRestoreGUI_62_BP : Form
    {
        public BackupRestoreGUI_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        BackupRestoreBLL_62_BP _backupRestoreBLL_62_BP = new BackupRestoreBLL_62_BP();

        //Eventos
        private void BackupRestoreGUI_62_BP_Load(object sender, EventArgs e)
        {
            radioButtonBackup.Checked = true;
            radioButtonRestore.Checked = false;
        }
        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (radioButtonBackup.Checked)
            {
                MostrarDialogoBackup();
            }
            else if (radioButtonRestore.Checked) {
                MostrarDialogoRestore();
            }
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            if (radioButtonBackup.Checked)
            {
                HacerBackup();
            }
            else if (radioButtonRestore.Checked)
            {
                HacerRestore();
            }
        }
        //Funciones:
        private void MostrarDialogoBackup()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "Archivo Backup (*.bak)|*.bak";
            dlg.Title = "Seleccionar Ruta y Nombre para el Backup";

            dlg.FileName = $"Backup_BaseDatos_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxRuta.Text = dlg.FileName;
            }
        }
        private void MostrarDialogoRestore()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Archivo Backup (*.bak)|*.bak";
            dlg.Title = "Seleccionar Archivo Backup";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxRuta.Text = dlg.FileName;
            }
            textBoxRuta.Text = dlg.FileName;
        }
        private bool ValidarRutaBackup()
        {
            if (string.IsNullOrWhiteSpace(textBoxRuta.Text))
            {
                MessageBox.Show("Debe seleccionar una ruta.");
                return false;
            }

            string directorio = Path.GetDirectoryName(textBoxRuta.Text);

            if (string.IsNullOrWhiteSpace(directorio))
            {
                MessageBox.Show("Debe seleccionar una carpeta válida.");
                return false;
            }

            if (!Directory.Exists(directorio))
            {
                MessageBox.Show("La carpeta seleccionada no existe.");
                return false;
            }

            if (!string.Equals(Path.GetExtension(textBoxRuta.Text),".bak",StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El archivo debe tener extensión .bak.");
                return false;
            }

            return true;
        }
        private bool ValidarRutaRestore()
        {
            if (string.IsNullOrWhiteSpace(textBoxRuta.Text))
            {
                MessageBox.Show("Debe seleccionar un archivo de Backup.");
                return false;
            }

            if (!File.Exists(textBoxRuta.Text))
            {
                MessageBox.Show("El archivo seleccionado no existe.");
                return false;
            }

            if (!string.Equals(
                Path.GetExtension(textBoxRuta.Text),
                ".bak",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Debe seleccionar un archivo con extensión .bak.");
                return false;
            }

            return true;
        }

        private bool HacerBackup()
        {
            try
            {
                if (ValidarRutaBackup())
                {
                    int resultado = _backupRestoreBLL_62_BP.RealizarBackup_62_BP(textBoxRuta.Text);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Backup creado con éxito.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo realizar el Backup.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar el Backup: " + ex.Message);
            }
            return false;
        }

        private bool HacerRestore()
        {
            try
            {
                if (ValidarRutaRestore())
                {
                    int resultado = _backupRestoreBLL_62_BP.RealizarRestore_62_BP(textBoxRuta.Text);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Restore realizado con éxito.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo realizar el Restore.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar el Restore: " + ex.Message);
            }
            return false;
        }

    }
}
