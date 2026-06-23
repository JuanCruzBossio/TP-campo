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
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class BackupRestoreGUI_62_BP : LocalizableForm_62_BP
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
                MostrarMensaje_62_BP("msg_backup_ruta_obligatoria", "Debe seleccionar una ruta.");
                return false;
            }

            string directorio = Path.GetDirectoryName(textBoxRuta.Text);

            if (string.IsNullOrWhiteSpace(directorio))
            {
                MostrarMensaje_62_BP("msg_backup_carpeta_valida", "Debe seleccionar una carpeta valida.");
                return false;
            }

            if (!Directory.Exists(directorio))
            {
                MostrarMensaje_62_BP("msg_backup_carpeta_no_existe", "La carpeta seleccionada no existe.");
                return false;
            }

            if (!string.Equals(Path.GetExtension(textBoxRuta.Text),".bak",StringComparison.OrdinalIgnoreCase))
            {
                MostrarMensaje_62_BP("msg_backup_extension_bak", "El archivo debe tener extension .bak.");
                return false;
            }

            return true;
        }
        private bool ValidarRutaRestore()
        {
            if (string.IsNullOrWhiteSpace(textBoxRuta.Text))
            {
                MostrarMensaje_62_BP("msg_restore_archivo_obligatorio", "Debe seleccionar un archivo de Backup.");
                return false;
            }

            if (!File.Exists(textBoxRuta.Text))
            {
                MostrarMensaje_62_BP("msg_restore_archivo_no_existe", "El archivo seleccionado no existe.");
                return false;
            }

            if (!string.Equals(
                Path.GetExtension(textBoxRuta.Text),
                ".bak",
                StringComparison.OrdinalIgnoreCase))
            {
                MostrarMensaje_62_BP("msg_restore_extension_bak", "Debe seleccionar un archivo con extension .bak.");
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
                        MostrarMensaje_62_BP("msg_backup_exito", "Backup creado con exito.");
                        return true;
                    }
                    else
                    {
                        MostrarMensaje_62_BP("msg_backup_error", "No se pudo realizar el Backup.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_backup_error_detalle", "Ocurrio un error al intentar realizar el Backup: {0}", ex.Message));
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
                        MostrarMensaje_62_BP("msg_restore_exito", "Restore realizado con exito.");
                        return true;
                    }
                    else
                    {
                        MostrarMensaje_62_BP("msg_restore_error", "No se pudo realizar el Restore.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_restore_error_detalle", "Ocurrio un error al intentar realizar el Restore: {0}", ex.Message));
            }
            return false;
        }

    }
}
