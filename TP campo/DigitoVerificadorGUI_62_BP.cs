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
using TP_campo_62_BP;

namespace TP_campo
{
    
    public partial class DigitoVerificadorGUI_62_BP : LocalizableForm_62_BP
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
        List<DigitoVerificadorVertical_62_BP> _listaErroresDVV_62_BP = new List<DigitoVerificadorVertical_62_BP>();
        DigitoVerificadorVertical_62_BP _dvvSeleccionado_62_BP = new DigitoVerificadorVertical_62_BP();
        
        //Eventos
        private void DigitoVerificadorGUI_62_BP_Load(object sender, EventArgs e)
        {
            buttonRecalcular.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(14);
            buttonBackupRestore.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(11);
            LlenarTablaErrores();
        }


        private void buttonRecalcular_Click(object sender, EventArgs e)
        {
            RecalcularDigitosVerificadores();
        }

        //Funciones:
        public void LlenarTablaErrores()
        {
            _listaErroresDVV_62_BP = new List<DigitoVerificadorVertical_62_BP>();
            DigitoVerificadorVertical_62_BP tabla = new DigitoVerificadorVertical_62_BP();

            if (_bitacoraBLL_62_BP.BuscarErrorDVH_62_BP().Count > 0)
            {
                tabla.Tabla_62_BP = "Bitacora_62_BP";
                _listaErroresDVV_62_BP.Add(tabla);
            }

            if (_familiaBLL_62_BP.BuscarErrorDVH_62_BP().Count > 0)
            {
                tabla.Tabla_62_BP = "Familia_62_BP";
                _listaErroresDVV_62_BP.Add(tabla);
            }

            if (_patenteBLL_62_BP.BuscarErrorDVH_62_BP().Count > 0)
            {
                tabla.Tabla_62_BP = "Patente_62_BP";
                _listaErroresDVV_62_BP.Add(tabla);
            }

            if (_rolBLL_62_BP.BuscarErrorDVH_62_BP().Count > 0)
            {
                tabla.Tabla_62_BP = "Rol_62_BP";
                _listaErroresDVV_62_BP.Add(tabla);
            }

            if (_usuarioBLL_62_BP.BuscarErrorDVH_62_BP().Count > 0) {
                tabla.Tabla_62_BP = "Usuario_62_BP";
                _listaErroresDVV_62_BP.Add(tabla);
            }

            foreach (var dvv in _dvvBLL_62_BP.BuscarErroresDVV_62_BP())
            {
                if (!_listaErroresDVV_62_BP.Any(error => error.Tabla_62_BP == dvv.Tabla_62_BP))
                {
                    _listaErroresDVV_62_BP.Add(dvv);
                }
            }
            
            dataGridViewErrores.DataSource = null;
            dataGridViewErrores.DataSource = _listaErroresDVV_62_BP;
            dataGridViewErrores.Columns["DVV_62_BP"].Visible = false;
            if (_listaErroresDVV_62_BP.Count > 0)
            {
                string tablasConError = string.Join(", ", _listaErroresDVV_62_BP.Select(x => x.Tabla_62_BP));
                MessageBox.Show(TextoFormato_62_BP("msg_dvv_tablas_error", "Se detectaron errores de Dígitos Verificadores."));
            }
            else
            {
                dataGridViewErrores.DataSource = null;
                buttonRecalcular.Enabled = false;
                MessageBox.Show(TextoFormato_62_BP("msg_dvv_sin_errores", "No se detectaron errores en las tablas."));
            }
        }
        public bool RecalcularDigitosVerificadores()
        {
            try
            {
                int resultado = 0;

                foreach (DigitoVerificadorVertical_62_BP tabla in _listaErroresDVV_62_BP)
                {
                    switch (tabla.Tabla_62_BP)
                    {
                        case "Bitacora_62_BP":
                            resultado += _bitacoraBLL_62_BP.RecalcularBitacorasDVH_62_BP();
                            break;
                        case "Familia_62_BP":
                            resultado += _familiaBLL_62_BP.RecalcularFamiliasDVH_62_BP();
                            break;
                        case "Patente_62_BP":
                            resultado += _patenteBLL_62_BP.RecalcularPatentesDVH_62_BP();
                            break;
                        case "Rol_62_BP":
                            resultado += _rolBLL_62_BP.RecalcularRolesDVH_62_BP();
                            break;
                        case "Usuario_62_BP":
                            resultado += _usuarioBLL_62_BP.RecalcularUsuariosDVH_62_BP();
                            break;
                    }
                }
                if (resultado > 0)
                {
                    MostrarMensaje_62_BP("msg_dvv_recalculados", "Digitos verificadores recalculados correctamente.");
                    dataGridViewErrores.DataSource = null;
                    buttonRecalcular.Enabled = false;
                    return true;
                }
                else
                {
                    MostrarMensaje_62_BP("msg_dvv_recalcular_error", "No se pudo recalcular digitos verificadores.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_dvv_recalcular_error_detalle", "Ocurrio un error al intentar recalcular digitos verificadores. {0}", TraducirExcepcion_62_BP(ex)));
            }
            return false;
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
