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
using BLL_62_BP;
using SEG;
using SEG_62_BP;

namespace TP_campo
{
    public partial class DigitoVerificadorGUI_62_BP : Form
    {
        public DigitoVerificadorGUI_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        DigitoVerificadorBLL_62_BP _dvvBLL_62_BP = new DigitoVerificadorBLL_62_BP();
        BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        FamiliaBLL_62_BP _familiaBLL_62_BP = new FamiliaBLL_62_BP();
        PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();
        RolBLL_62_BP _rolBLL_62_BP = new RolBLL_62_BP();
        UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();
        List<DigitoVerificadorVertical_62_BP> _listaDVV_62_BP = new List<DigitoVerificadorVertical_62_BP>();
        DigitoVerificadorVertical_62_BP _dvvSeleccionado_62_BP = new DigitoVerificadorVertical_62_BP();
        
        //Eventos
        private void DigitoVerificadorGUI_62_BP_Load(object sender, EventArgs e)
        {
            AcutualizarComboDVV();
        }

        private void buttonRevisarDVV_Click(object sender, EventArgs e)
        {
            if (_dvvSeleccionado_62_BP.DVV_62_BP != _dvvBLL_62_BP.CalcularDVV_62_BP(_dvvSeleccionado_62_BP.Tabla_62_BP))
            {
                LlenarTablaErrores();
            }
            else {
                dataGridViewErrores.DataSource = null;
                MessageBox.Show("NO se detectaron errores la tabla " + _dvvSeleccionado_62_BP.Tabla_62_BP);
            }
        }

        private void comboBoxTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dvvSeleccionado_62_BP = (DigitoVerificadorVertical_62_BP)comboBoxTablas.SelectedItem;
        }

        private void buttonRecalcular_Click(object sender, EventArgs e)
        {
            RecalcularDigitosVerificadores();
        }

        //Funciones:
        public void LlenarTablaErrores()
        {
            object datosTabla = null;
            switch (_dvvSeleccionado_62_BP.Tabla_62_BP)
            {
                case "Bitacora_62_BP":
                    datosTabla = _bitacoraBLL_62_BP.BuscarErrorDVH_62_BP();
                    break;
                case "Familia_62_BP":
                    datosTabla = _familiaBLL_62_BP.BuscarErrorDVH_62_BP();
                    break;
                case "Patente_62_BP":
                    datosTabla = _patenteBLL_62_BP.BuscarErrorDVH_62_BP();
                    break;
                case "Rol_62_BP":
                    datosTabla = _rolBLL_62_BP.BuscarErrorDVH_62_BP();
                    break;
                case "Usuario_62_BP":
                    datosTabla = _usuarioBLL_62_BP.BuscarErrorDVH_62_BP();
                    break;
            }
            

            if (datosTabla != null && ((System.Collections.IList)datosTabla).Count > 0)
            {
                dataGridViewErrores.DataSource = datosTabla;
                MessageBox.Show("Se detectaron errores en los siguientes Registros de la tabla " + _dvvSeleccionado_62_BP.Tabla_62_BP);
            }
            else
            {
                MessageBox.Show("Se detectó al menos un Registro eliminado en la tabla " + _dvvSeleccionado_62_BP.Tabla_62_BP);
            }
        }
        public bool RecalcularDigitosVerificadores()
        {
            try
            {
                int resultado = 0;
                switch (_dvvSeleccionado_62_BP.Tabla_62_BP)
                {
                    case "Bitacora_62_BP":
                        resultado = _bitacoraBLL_62_BP.RecalcularBitacorasDVH_62_BP();
                        break;
                    case "Familia_62_BP":
                        resultado = _familiaBLL_62_BP.RecalcularFamiliasDVH_62_BP();
                        break;
                    case "Patente_62_BP":
                        resultado = _patenteBLL_62_BP.RecalcularPatentesDVH_62_BP();
                        break;
                    case "Rol_62_BP":
                        resultado = _rolBLL_62_BP.RecalcularRolesDVH_62_BP();
                        break;
                    case "Usuario_62_BP":
                        resultado = _usuarioBLL_62_BP.RecalcularUsuariosDVH_62_BP();
                        break;
                }
                if (resultado > 0)
                {
                    MessageBox.Show("Digitos Verificadores Recalculados Correctamente.");
                    dataGridViewErrores.DataSource = null;
                    AcutualizarComboDVV();
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo recalcular Digitos Verificadores.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar Recalcular Digitos Verificadores. " + ex.Message);
            }
            return false;
        }
        public void AcutualizarComboDVV()
        {
            _listaDVV_62_BP = _dvvBLL_62_BP.BuscarDVVs_62_BP();
            comboBoxTablas.DataSource = _listaDVV_62_BP;
            comboBoxTablas.DisplayMember = "Tabla_62_BP";
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
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

        private void buttonBackupRestore_Click(object sender, EventArgs e)
        {
            BackupRestoreGUI_62_BP BackupRestoreForm = new BackupRestoreGUI_62_BP();
            BackupRestoreForm.Show();
            this.Close();
        }
    }
}
